# IEXStock

## Basic Routes:

### IEX/Price/{symbol}
returns a string of the symbols price.

### IEX/PreviousDay/{symbol}
returns an IEXPreviousDay model with some information about the previous day
Example:
```json
{
  "symbol": "MSFT",
  "date": "2019-03-08",
  "open": 109.16,
  "high": 110.71,
  "low": 108.8,
  "close": 110.51,
  "volume": 22818430,
  "unadjustedVolume": 22818430,
  "change": 0.12,
  "changePercent": 0.109,
  "vwap": 109.7359
}
````
### IEX/OfficialOpenAndClose/{symbol}
returns an IEXOfficalOpenAndClose model with some information about the offical open and close time and price
Example: 
```json
{
  "open": {
    "price": 110.99,
    "time": 1552311000959
  },
  "close": {
  "price": 112.83,
  "time": 1552334400579
  },
  "high": 112.95,
  "low": 110.98
}
```
### IEX/StockStats/{symbol}
returns an IEXStockStats model with a lot of information about the stock

Example:
```json
{
  "companyName": "Microsoft Corporation",
  "marketcap": 847856307917,
  "beta": 1.222179,
  "week52high": 116.18,
  "week52low": 87.08,
  "week52change": 19.003899,
  "shortInterest": 0,
  "shortDate": 0,
  "dividendRate": 1.84,
  "dividendYield": 1.6650077,
  "exDividendDate": "2019-02-20 00:00:00.0",
  "latestEPS": 2.11,
  "latestEPSDate": "2018-06-30",
  "sharesOutstanding": 7672213446,
  "float": 7212510008,
  "returnOnEquity": 39.35,
  "consensusEPS": 1.07,
  "numberOfEstimates": 14,
  "EPSSurpriseDollar": null,
  "EPSSurprisePercent": 5.6075,
  "symbol": "MSFT",
  "EBITDA": 0,
  "revenue": 0,
  "grossProfit": 0,
  "cash": 0,
  "debt": 0,
  "ttmEPS": 3.88,
  "revenuePerShare": 0,
  "revenuePerEmployee": 0,
  "peRatioHigh": 38.4,
  "peRatioLow": 11.9,
  "returnOnAssets": 13.03,
  "returnOnCapital": null,
  "profitMargin": 28.31,
  "priceToSales": 7.14961,
  "priceToBook": 9.2,
  "day200MovingAvg": 105.56957,
  "day50MovingAvg": 105.8774,
  "institutionPercent": 114,
  "insiderPercent": 6,
  "shortRatio": null,
  "year5ChangePercent": 2.2673419547876272,
  "year2ChangePercent": 0.7729654455436016,
  "year1ChangePercent": 0.1612633401846925,
  "ytdChangePercent": 0.09752815327058634,
  "month6ChangePercent": 0.001990198611847899,
  "month3ChangePercent": 0.022027556178684175,
  "month1ChangePercent": 0.054460584872102154,
  "day5ChangePercent": -0.015588811687154818,
  "day30ChangePercent": 0.03556977421936349
}
```
### IEX/LargestTradesToday/{symbol}
returns a list of IEXLargestTradesToday models with information about theamount at what price and which exchange was used.

Example:
```json
[
  {
    "price": 111.995,
    "size": 84500,
    "time": 1552311702010,
    "timeLabel": "09:41:42",
    "venue": "None",
    "venueName": "Off Exchange"
  },
  {
    "price": 112,
    "size": 27000,
    "time": 1552311672522,
    "timeLabel": "09:41:12",
    "venue": "None",
    "venueName": "Off Exchange"
  },
  {
    "price": 112.765,
    "size": 21000,
    "time": 1552325287333,
    "timeLabel": "13:28:07",
    "venue": "None",
    "venueName": "Off Exchange"
  },
  {
    "price": 112.18,
    "size": 20000,
    "time": 1552314604920,
    "timeLabel": "10:30:04",
    "venue": "None",
    "venueName": "Off Exchange"
  },
  {
    "price": 112.17,
    "size": 20000,
    "time": 1552314644384,
    "timeLabel": "10:30:44",
    "venue": "None",
    "venueName": "Off Exchange"
  },
  {
    "price": 112.495,
    "size": 20000,
    "time": 1552323906533,
    "timeLabel": "13:05:06",
    "venue": "None",
    "venueName": "Off Exchange"
  },
  {
    "price": 112.64,
    "size": 18387,
    "time": 1552321109877,
    "timeLabel": "12:18:29",
    "venue": "None",
    "venueName": "Off Exchange"
  },
  {
    "price": 112.775,
    "size": 15700,
    "time": 1552334263982,
    "timeLabel": "15:57:43",
    "venue": "None",
    "venueName": "Off Exchange"
  },
  {
    "price": 112.83,
    "size": 15451,
    "time": 1552334400000,
    "timeLabel": "16:00:00",
    "venue": "None",
    "venueName": "Off Exchange"
  },
  {
    "price": 112.231,
    "size": 15000,
    "time": 1552313386029,
    "timeLabel": "10:09:46",
    "venue": "None",
    "venueName": "Off Exchange"
  }
]
```

### IEX/Logo/{symbol}
returns an IEXLogo model with the url to an image.

Example: 

```json
{
  "url": "https://storage.googleapis.com/iex/api/logos/MSFT.png"
}
```
### IEX/Earning/{symbol}
returns te last 4 years if available.

Example:
```json
{
  "symbol": "MSFT",
  "earnings": 
  [
    {
      "actualEPS": 1.1,
      "consensusEPS": 1.09,
      "estimatedEPS": 1.09,
      "announceTime": "AMC",
      "numberOfEstimates": 14,
      "EPSSurpriseDollar": 0.01,
      "EPSReportDate": "2019-01-30",
      "fiscalPeriod": "Q2 2019",
      "fiscalEndDate": "2018-12-31",
      "yearAgo": 0.96,
      "yearAgoChangePercent": 0.14583333333333348,
      "estimatedChangePercent": 0.1354166666666668,
      "symbolId": 4563
    },
    {
      "actualEPS": 1.14,
      "consensusEPS": 0.96,
      "estimatedEPS": 0.96,
      "announceTime": "AMC",
      "numberOfEstimates": 15,
      "EPSSurpriseDollar": 0.18,
      "EPSReportDate": "2018-10-24",
      "fiscalPeriod": "Q1 2019",
      "fiscalEndDate": "2018-09-30",
      "yearAgo": 0.84,
      "yearAgoChangePercent": 0.3571428571428571,
      "estimatedChangePercent": 0.14285714285714285,
      "symbolId": 4563
    },
    {
      "actualEPS": 1.13,
      "consensusEPS": 1.07,
      "estimatedEPS": 1.07,
      "announceTime": "AMC",
      "numberOfEstimates": 14,
      "EPSSurpriseDollar": 0.06,
      "EPSReportDate": "2018-07-19",
      "fiscalPeriod": "Q4 2018",
      "fiscalEndDate": "2018-06-30",
      "yearAgo": 0.98,
      "yearAgoChangePercent": 0.15306122448979584,
      "estimatedChangePercent": 0.09183673469387764,
      "symbolId": 4563
    },
    {
      "actualEPS": 0.95,
      "consensusEPS": 0.85,
      "estimatedEPS": 0.85,
      "announceTime": "AMC",
      "numberOfEstimates": 14,
      "EPSSurpriseDollar": 0.1,
      "EPSReportDate": "2018-04-26",
      "fiscalPeriod": "Q3 2018",
      "fiscalEndDate": "2018-03-31",
      "yearAgo": 0.73,
      "yearAgoChangePercent": 0.3013698630136986,
      "estimatedChangePercent": 0.1643835616438356,
      "symbolId": 4563
    }
  ]
}
```
### IEX/Chart/{symbol}
returns a list of the last 30 days worth of trades.

Example: 
```json
[
  {
    "date": "2019-02-11",
    "open": 171.05,
    "high": 171.21,
    "low": 169.25,
    "close": 169.43,
    "volume": 20993425,
    "unadjustedVolume": 20993425,
    "change": -0.98,
    "changePercent": -0.575,
    "vwap": 169.9464,
    "label": "Feb 11",
    "changeOverTime": 0
  },
  {
    "date": "2019-02-12",
    "open": 170.1,
    "high": 171,
    "low": 169.7,
    "close": 170.89,
    "volume": 22283523,
    "unadjustedVolume": 22283523,
    "change": 1.46,
    "changePercent": 0.862,
    "vwap": 170.3732,
    "label": "Feb 12",
    "changeOverTime": 0.008617128017470221
  },
  {
    "date": "2019-02-13",
    "open": 171.39,
    "high": 172.48,
    "low": 169.92,
    "close": 170.18,
    "volume": 22490233,
    "unadjustedVolume": 22490233,
    "change": -0.71,
    "changePercent": -0.415,
    "vwap": 171.0037,
    "label": "Feb 13",
    "changeOverTime": 0.004426606858289559
  },
  {
    "date": "2019-02-14",
    "open": 169.71,
    "high": 171.2615,
    "low": 169.38,
    "close": 170.8,
    "volume": 21835747,
    "unadjustedVolume": 21835747,
    "change": 0.62,
    "changePercent": 0.364,
    "vwap": 170.6527,
    "label": "Feb 14",
    "changeOverTime": 0.00808593519447562
  },
  {
    "date": "2019-02-15",
    "open": 171.25,
    "high": 171.7,
    "low": 169.75,
    "close": 170.42,
    "volume": 24626814,
    "unadjustedVolume": 24626814,
    "change": -0.38,
    "changePercent": -0.222,
    "vwap": 170.4848,
    "label": "Feb 15",
    "changeOverTime": 0.0058431210529421036
  },
  {
    "date": "2019-02-19",
    "open": 169.71,
    "high": 171.44,
    "low": 169.49,
    "close": 170.93,
    "volume": 18972826,
    "unadjustedVolume": 18972826,
    "change": 0.51,
    "changePercent": 0.299,
    "vwap": 170.52,
    "label": "Feb 19",
    "changeOverTime": 0.008853213716579118
  },
  {
    "date": "2019-02-20",
    "open": 171.19,
    "high": 173.32,
    "low": 170.99,
    "close": 172.03,
    "volume": 26114362,
    "unadjustedVolume": 26114362,
    "change": 1.1,
    "changePercent": 0.644,
    "vwap": 172.2129,
    "label": "Feb 20",
    "changeOverTime": 0.015345570442070437
  },
  {
    "date": "2019-02-21",
    "open": 171.8,
    "high": 172.37,
    "low": 170.3,
    "close": 171.06,
    "volume": 17249670,
    "unadjustedVolume": 17249670,
    "change": -0.97,
    "changePercent": -0.564,
    "vwap": 171.116,
    "label": "Feb 21",
    "changeOverTime": 0.009620492238682615
  },
  {
    "date": "2019-02-22",
    "open": 171.58,
    "high": 173,
    "low": 171.38,
    "close": 172.97,
    "volume": 18913154,
    "unadjustedVolume": 18913154,
    "change": 1.91,
    "changePercent": 1.117,
    "vwap": 172.3528,
    "label": "Feb 22",
    "changeOverTime": 0.02089358437112667
  },
  {
    "date": "2019-02-25",
    "open": 174.16,
    "high": 175.87,
    "low": 173.95,
    "close": 174.23,
    "volume": 21873358,
    "unadjustedVolume": 21873358,
    "change": 1.26,
    "changePercent": 0.728,
    "vwap": 174.8641,
    "label": "Feb 25",
    "changeOverTime": 0.028330283893053077
  },
  {
    "date": "2019-02-26",
    "open": 173.71,
    "high": 175.3,
    "low": 173.1732,
    "close": 174.33,
    "volume": 17070211,
    "unadjustedVolume": 17070211,
    "change": 0.1,
    "changePercent": 0.057,
    "vwap": 174.3702,
    "label": "Feb 26",
    "changeOverTime": 0.028920498140825153
  },
  {
    "date": "2019-02-27",
    "open": 173.21,
    "high": 175,
    "low": 172.73,
    "close": 174.87,
    "volume": 27835389,
    "unadjustedVolume": 27835389,
    "change": 0.54,
    "changePercent": 0.31,
    "vwap": 174.1866,
    "label": "Feb 27",
    "changeOverTime": 0.03210765507879359
  },
  {
    "date": "2019-02-28",
    "open": 174.32,
    "high": 174.91,
    "low": 172.92,
    "close": 173.15,
    "volume": 28215416,
    "unadjustedVolume": 28215416,
    "change": -1.72,
    "changePercent": -0.984,
    "vwap": 173.7766,
    "label": "Feb 28",
    "changeOverTime": 0.021955970017116206
  },
  {
    "date": "2019-03-01",
    "open": 174.28,
    "high": 175.15,
    "low": 172.89,
    "close": 174.97,
    "volume": 25886167,
    "unadjustedVolume": 25886167,
    "change": 1.82,
    "changePercent": 1.051,
    "vwap": 174.2926,
    "label": "Mar 1",
    "changeOverTime": 0.032697869326565494
  },
  {
    "date": "2019-03-04",
    "open": 175.69,
    "high": 177.75,
    "low": 173.97,
    "close": 175.85,
    "volume": 27436203,
    "unadjustedVolume": 27436203,
    "change": 0.88,
    "changePercent": 0.503,
    "vwap": 175.9435,
    "label": "Mar 4",
    "changeOverTime": 0.037891754706958554
  },
  {
    "date": "2019-03-05",
    "open": 175.94,
    "high": 176,
    "low": 174.54,
    "close": 175.53,
    "volume": 19737419,
    "unadjustedVolume": 19737419,
    "change": -0.32,
    "changePercent": -0.182,
    "vwap": 175.36,
    "label": "Mar 5",
    "changeOverTime": 0.036003069114088376
  },
  {
    "date": "2019-03-06",
    "open": 174.67,
    "high": 175.49,
    "low": 173.94,
    "close": 174.52,
    "volume": 20810384,
    "unadjustedVolume": 20810384,
    "change": -1.01,
    "changePercent": -0.575,
    "vwap": 174.743,
    "label": "Mar 6",
    "changeOverTime": 0.030041905211591828
  },
  {
    "date": "2019-03-07",
    "open": 173.87,
    "high": 174.44,
    "low": 172.02,
    "close": 172.5,
    "volume": 24796374,
    "unadjustedVolume": 24796374,
    "change": -2.02,
    "changePercent": -1.157,
    "vwap": 173.0614,
    "label": "Mar 7",
    "changeOverTime": 0.018119577406598555
  },
  {
    "date": "2019-03-08",
    "open": 170.32,
    "high": 173.07,
    "low": 169.5,
    "close": 172.91,
    "volume": 23999358,
    "unadjustedVolume": 23999358,
    "change": 0.41,
    "changePercent": 0.238,
    "vwap": 171.8064,
    "label": "Mar 8",
    "changeOverTime": 0.020539455822463495
  }
]
```

### IEX/Markets
returns information about the big exchanges that IEX tracks.
```json
Example:
[
  {
    "mic": "TRF",
    "tapeId": "",
    "venueName": "TRF Volume",
    "volume": 2597497450,
    "tapeA": 1271826632,
    "tapeB": 423382252,
    "tapeC": 902288566,
    "marketPercent": 0.36433,
    "lastUpdated": 1552339066912
  },
  {
    "mic": "XNGS",
    "tapeId": "Q",
    "venueName": "NASDAQ",
    "volume": 1181705886,
    "tapeA": 429741091,
    "tapeB": 148861939,
    "tapeC": 603102856,
    "marketPercent": 0.16575,
    "lastUpdated": 1552339062268
  },
  {
    "mic": "XNYS",
    "tapeId": "N",
    "venueName": "NYSE",
    "volume": 1005970612,
    "tapeA": 919513868,
    "tapeB": 44388369,
    "tapeC": 42068375,
    "marketPercent": 0.1411,
    "lastUpdated": 1552337100062
  },
  {
    "mic": "ARCX",
    "tapeId": "P",
    "venueName": "NYSE Arca",
    "volume": 629992609,
    "tapeA": 191482901,
    "tapeB": 267501215,
    "tapeC": 171008493,
    "marketPercent": 0.08836,
    "lastUpdated": 1552339066698
  },
  {
    "mic": "BATS",
    "tapeId": "Z",
    "venueName": "BATS BZX",
    "volume": 353710528,
    "tapeA": 176811171,
    "tapeB": 72523768,
    "tapeC": 104375589,
    "marketPercent": 0.04961,
    "lastUpdated": 1552338862708
  },
  {
    "mic": "BATY",
    "tapeId": "Y",
    "venueName": "BATS BYX",
    "volume": 296899332,
    "tapeA": 161628858,
    "tapeB": 63898873,
    "tapeC": 71371601,
    "marketPercent": 0.04164,
    "lastUpdated": 1552338989529
  },
  {
    "mic": "EDGX",
    "tapeId": "K",
    "venueName": "EDGX",
    "volume": 291040705,
    "tapeA": 134347376,
    "tapeB": 53538156,
    "tapeC": 103155173,
    "marketPercent": 0.04082,
    "lastUpdated": 1552339057229
  },
  {
    "mic": "IEXG",
    "tapeId": "V",
    "venueName": "IEX",
    "volume": 197651514,
    "tapeA": 121530492,
    "tapeB": 17864907,
    "tapeC": 58256115,
    "marketPercent": 0.02772,
    "lastUpdated": 1552337959067
  },
  {
    "mic": "EDGA",
    "tapeId": "J",
    "venueName": "EDGA",
    "volume": 169380827,
    "tapeA": 92126309,
    "tapeB": 35813453,
    "tapeC": 41441065,
    "marketPercent": 0.02376,
    "lastUpdated": 1552339054932
  },
  {
    "mic": "XBOS",
    "tapeId": "B",
    "venueName": "NASDAQ BX",
    "volume": 165660746,
    "tapeA": 95805539,
    "tapeB": 21323592,
    "tapeC": 48531615,
    "marketPercent": 0.02324,
    "lastUpdated": 1552339041975
  },
  {
    "mic": "XCIS",
    "tapeId": "C",
    "venueName": "NYSE National",
    "volume": 93950252,
    "tapeA": 52702700,
    "tapeB": 17502587,
    "tapeC": 23744965,
    "marketPercent": 0.01318,
    "lastUpdated": 1552337988383
  },
  {
    "mic": "XCHI",
    "tapeId": "M",
    "venueName": "CHX",
    "volume": 69105651,
    "tapeA": 47648684,
    "tapeB": 9159859,
    "tapeC": 12297108,
    "marketPercent": 0.00969,
    "lastUpdated": 1552335335177
  },
  {
    "mic": "XPHL",
    "tapeId": "X",
    "venueName": "NASDAQ PSX",
    "volume": 53855074,
    "tapeA": 19693531,
    "tapeB": 20313642,
    "tapeC": 13847901,
    "marketPercent": 0.00755,
    "lastUpdated": 1552337938580
  },
  {
    "mic": "XASE",
    "tapeId": "A",
    "venueName": "NYSE American",
    "volume": 23080610,
    "tapeA": 6261340,
    "tapeB": 14263866,
    "tapeC": 2555404,
    "marketPercent": 0.00324,
    "lastUpdated": 1552338455129
  }
]
```

### IEX/TOPS
returns a select number of stock if no parameters returns all stocks tracked by IEX.
```json
[
  {
    "symbol": "SNAP",
    "sector": "mediaentertainment",
    "securityType": "commonstock",
    "bidPrice": 0,
    "bidSize": 0,
    "askPrice": 0,
    "askSize": 0,
    "lastUpdated": 1552334791437,
    "lastSalePrice": 9.965,
    "lastSaleSize": 70,
    "lastSaleTime": 1552334394357,
    "volume": 506202,
    "marketPercent": 0.02361
  },
  {
    "symbol": "FB",
    "sector": "mediaentertainment",
    "securityType": "commonstock",
    "bidPrice": 0,
    "bidSize": 0,
    "askPrice": 0,
    "askSize": 0,
    "lastUpdated": 1552336772380,
    "lastSalePrice": 171.91,
    "lastSaleSize": 8,
    "lastSaleTime": 1552334400968,
    "volume": 354493,
    "marketPercent": 0.01927
  },
  {
    "symbol": "MSFT",
    "sector": "softwareservices",
    "securityType": "commonstock",
    "bidPrice": 0,
    "bidSize": 0,
    "askPrice": 0,
    "askSize": 0,
    "lastUpdated": 1552336907311,
    "lastSalePrice": 112.785,
    "lastSaleSize": 6,
    "lastSaleTime": 1552334396105,
    "volume": 477117,
    "marketPercent": 0.01979
  }
  ```
]
