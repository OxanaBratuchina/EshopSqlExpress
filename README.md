This project has been created as ASP Net Web API Core.
It uses EntityFrameworkCore 8 for working with SQLExpress.
DataBase EshopDb has 3 tables, Product, Order and OrderProduct (for connection ManyToMany). Table Product is filled on start of controller working.
OrdersController has 3 methods:
-Get - for getting of all orders
-post - for creating of new order
-post {id}/payment for payment accepting (put payment info to special asynch queue)

Service PaymentService takes PaymentInfo from queue and updates payment info to order tables (payed attribute)

Added authorizarion oauth2 (JWT token using)

