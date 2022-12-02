# Description
Simple gRPC service created for calculate calories demand, just for train gRPC (proto3).

# Tests
To check how it works, configure and run the request through the Postman https://www.postman.com

Change the values if necessary in CaloriesCalculator/Properties/launchSettings.json by default the address is assigned as: "https//localhost:5001"

# Pattern
The pattern for possible calculations is introduced by @inzynieria.masy on instagram, you can follow them using this link https://www.instagram.com/inzynieria.masy/

## Basic metabilism pattern
> Male: 66,47 + (13,7 * weight) + (5,0 * weight) - (6,76 * height)

> Female: 655,1 + (9,567 * weight) + (1,85 * weight) - (4,68 * height)

## Total metabolism pattern

> total = basic metabolism * activity level (determined according to the values from table)

# Activity information 
| Activity level | Female | Male | Example |
| ---: | :---: | :---: | :---: |
| none | 1,1 | 1,1 | no excercises |
| very low | 1,2 | 1,2 | sedentary lifestyle,<br> only shopping </br> |
| low | 1,4 | 1,5 | occasional walk,<br> treining 1-2 times per week </br> |
| average | 1,5 | 1,6 | 8-10k steps per day,<br> treining 3-4 times per week </br> |
| high | 1,8 | 2,0 | physical work,<br> treining 4-5 times per week </br> |
| very high | 2,1 | 2,3 | professional sportsman,<br> heavy physical work + treinings </br> |

# Packages info 

| Name  | Version  |
|---|---|
| Calzolari.Grpc.AspNetCore.Validation | 3.5.0 |
| Grpc.AspNetCore | 2.39.0 |
| Moq | 4.18.2 |
| xunit | 2.4.1 |

The `Calzolari.Grpc.AspNetCore.Validation` package is used to make validations on the gRPC request - it is called before the actual request (proto3 format no longer officially supports keyword `required` any longer, which is the reason for using this package).

More details on this package can be found here: https://anthonygiretti.com/2020/05/18/grpc-asp-net-core-3-1-model-validation/