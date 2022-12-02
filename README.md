# Description
Simple gRPC service created for calculate calories demand, just for train gRPC (proto3).

# Tests
To check how does it work, please configure and run request via Postman https://www.postman.com

Then change the values if needed in CaloriesCalculator/Properties/launchSettings.json by default the address is assigned as: "https//localhost:5001"

# Pattern
The pattern to make possible calculations is introduced via @inzynieria.masy at the instagram, you can follow them by using this link https://www.instagram.com/inzynieria.masy/

## Basic metabilism pattern
> Male: 66,47 + (13,7 * weight) + (5,0 * weight) - (6,76 * height)

> Female: 655,1 + (9,567 * weight) + (1,85 * weight) - (4,68 * height)

## Total metabolism pattern

> total = basic metabolism * activity level (determined according to the values from table)

# Activity information 
| Activity level | Female | Male | Example |
| ---: | :---: | :---: | :---: |
| none | 1,1 | 1,1 | no excercises |
| very low | 1,2 | 1,2 | sitting lifestyle,<br> only shopping </br> |
| low | 1,4 | 1,5 | ocasionally walk,<br> treining 1-2 times per week </br> |
| average | 1,5 | 1,6 | 8-10k steps per day,<br> treining 3-4 times per week </br> |
| high | 1,8 | 2,0 | fizycal work,<br> treining 4-5 times per week </br> |
| very high | 2,1 | 2,3 | professional sportsmans,<br> heavy fizycal work + treinings </br> |

# Packages info 

| Name  | Version  |
|---|---|
| Calzolari.Grpc.AspNetCore.Validation | 3.5.0 |
| Grpc.AspNetCore | 2.39.0 |
| Moq | 4.18.2 |
| xunit | 2.4.1 |

The `Calzolari.Grpc.AspNetCore.Validation` package is used to make fluent validations on the gRPC request - it's called before real request (proto3 format does not officially support required tak any longer, that is the reason of use this package).

More details about this package you can fin in here: https://anthonygiretti.com/2020/05/18/grpc-asp-net-core-3-1-model-validation/