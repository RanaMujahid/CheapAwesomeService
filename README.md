# CheapAwesomeService
Excercise for Web Beds

API Specifications:

Language: C#

Framework: .Net Core 2.1

Design Patterns/Approaches: Dependency Injection, Http Client Factory

URL: http://localhost:3636/api/bargainsapi/GetBargainsForCouples

Method: GET

• Query String Parameters: 

1. destinationId,    (integer) Ex: 279, 1419 

2. nights,           (Integer Number of nights ) Ex: 15

3. code,             (String Secret authentication code): aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw==

Response Sample: (Response will be returned with list of hotels and final price per boardType)

NOTE: If rate type will be PerNight then value will be total rate w.r.t number of nights.

[
    {
        "hotel": {
            "propertyID": 79821,
            "name": "JAC Canada (CA$)8555",
            "geoId": 279,
            "rating": 3
        },
        "ratesPerBoardType": [
            {
                "boardType": "Half Board",
                "value": 6426.0
            },
            {
                "boardType": "No Meals",
                "value": 5508.0
            },
            {
                "boardType": "Full Board",
                "value": 7344.0
            }
        ]
    },
    {
        "hotel": {
            "propertyID": 79732,
            "name": "JAC Canada (CA$)8314",
            "geoId": 279,
            "rating": 3
        },
        "ratesPerBoardType": [
            {
                "boardType": "Half Board",
                "value": 12054.0
            },
            {
                "boardType": "No Meals",
                "value": 10332.0
            }
        ]
    }
]


