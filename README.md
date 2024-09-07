This project has been created as ASP Net Core.
TI uses EntityFrameworkCore for working with SQLExpress.
DataBase EshopDb has 3 tables, Product, Order and OrderProduct (for connection ManyToMany). Table Product is filled on start of controller working.
OrdersController has 3 methods:
-Get - for getting of all orders
-post - for creating of new order
-post {id}/payment for payment accepting

Service PaymentService takes PaymentInfo from queue and updates payment info to order tables (payrd attribute)
