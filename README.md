# Discount calcularator API

This is a restful .NET Core web API application which takes a
bill as an input, then finds the net payable amount acording to some set of conditions.

## Author

Doğuş Sezer

## Source

GitHub [link](https://pip.pypa.io/en/stable/)

## UML Diagram

Lucidcharts [link](https://lucid.app/lucidchart/0f7bc93f-4116-4a03-be60-bd53fe6a9dc6/edit?view_items=bf7lc.Kog7Ta&invitationId=inv_fe93614b-ccd8-4171-bc07-687df7010751)

## Usage

A bill object must be sent as a get message in json string format to the "hostUrl/api/discount/calculatediscount" route.

## Testing

-For testing with real data, sqlserver connection string which resides in startup file must be modified.
-Account, bill, and discount tables must be created with given relations.
-Test classes must be used for contrasting the results between mock data and real data.

