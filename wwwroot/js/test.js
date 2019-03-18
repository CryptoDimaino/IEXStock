
var skipWeekends = function () {

    // the indices returned by date.getDay()
    var day = {
        sunday: 0,
        monday: 1,
        saturday: 6
    };

    var millisPerDay = 24 * 3600 * 1000;
    var millisPerWorkWeek = millisPerDay * 5;
    var millisPerWeek = millisPerDay * 7;

    var skipWeekends = {};

    var isWeekend = function isWeekend(date) {
        return date.getDay() === 0 || date.getDay() === 6;
    };

    skipWeekends.clampDown = function (date) {
        if (date && isWeekend(date)) {
            // round the date up to midnight
            var newDate = d3Time.timeDay.ceil(date);
            // then subtract the required number of days
            if (newDate.getDay() === day.sunday) {
                return d3Time.timeDay.offset(newDate, -1);
            } else if (newDate.getDay() === day.monday) {
                return d3Time.timeDay.offset(newDate, -2);
            } else {
                return newDate;
            }
        } else {
            return date;
        }
    };

    skipWeekends.clampUp = function (date) {
        if (date && isWeekend(date)) {
            // round the date down to midnight
            var newDate = d3Time.timeDay.floor(date);
            // then add the required number of days
            if (newDate.getDay() === day.saturday) {
                return d3Time.timeDay.offset(newDate, 2);
            } else if (newDate.getDay() === day.sunday) {
                return d3Time.timeDay.offset(newDate, 1);
            } else {
                return newDate;
            }
        } else {
            return date;
        }
    };

    // returns the number of included milliseconds (i.e. those which do not fall)
    // within discontinuities, along this scale
    skipWeekends.distance = function (startDate, endDate) {
        startDate = skipWeekends.clampUp(startDate);
        endDate = skipWeekends.clampDown(endDate);

        // move the start date to the end of week boundary
        var offsetStart = d3Time.timeSaturday.ceil(startDate);
        if (endDate < offsetStart) {
            return endDate.getTime() - startDate.getTime();
        }

        var msAdded = offsetStart.getTime() - startDate.getTime();

        // move the end date to the end of week boundary
        var offsetEnd = d3Time.timeSaturday.ceil(endDate);
        var msRemoved = offsetEnd.getTime() - endDate.getTime();

        // determine how many weeks there are between these two dates
        // round to account for DST transitions
        var weeks = Math.round((offsetEnd.getTime() - offsetStart.getTime()) / millisPerWeek);

        return weeks * millisPerWorkWeek + msAdded - msRemoved;
    };

    skipWeekends.offset = function (startDate, ms) {
        var date = isWeekend(startDate) ? skipWeekends.clampUp(startDate) : startDate;

        if (ms === 0) {
            return date;
        }

        var isNegativeOffset = ms < 0;
        var isPositiveOffset = ms > 0;
        var remainingms = ms;

        // move to the end of week boundary for a postive offset or to the start of a week for a negative offset
        var weekBoundary = isNegativeOffset ? d3Time.timeMonday.floor(date) : d3Time.timeSaturday.ceil(date);
        remainingms -= weekBoundary.getTime() - date.getTime();

        // if the distance to the boundary is greater than the number of ms
        // simply add the ms to the current date
        if (isNegativeOffset && remainingms > 0 || isPositiveOffset && remainingms < 0) {
            return new Date(date.getTime() + ms);
        }

        // skip the weekend for a positive offset
        date = isNegativeOffset ? weekBoundary : d3Time.timeDay.offset(weekBoundary, 2);

        // add all of the complete weeks to the date
        var completeWeeks = Math.floor(remainingms / millisPerWorkWeek);
        date = d3Time.timeDay.offset(date, completeWeeks * 7);
        remainingms -= completeWeeks * millisPerWorkWeek;

        // add the remaining time
        date = new Date(date.getTime() + remainingms);
        return date;
    };

    skipWeekends.copy = function () {
        return skipWeekends;
    };

    return skipWeekends;
};