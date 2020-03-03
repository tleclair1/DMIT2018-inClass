# Order Processing - Implementation Plan

> Orders are shipped direcctly from our suppliers to our customers. As such, suppliers log onto our system to see what orders there are for the products they provide.

## User Interface

Suppliers will be interacting with a page that shows the following information.

![Mockup](./Shipping-Orders.svg)

## Implementation 

The form will primarily use a `<asp:ListView>` to represent the orders **(1)** and show the order items **(2)** in a `<asp:GridView>` inside of the ListView's `<SelectedItemTemplate>`.

![Mockup](./Order-Processing.png)

### Queries/Presentation

### Commands/Processing

