### User Cases:

#### Customer Management:
1. **Create a Customer**
   - **As an employee, I want to create a new customer with a name and email.**
   - `POST /customers`
   - *Response*: Created customer object.
   
2. **Retrieve All Customers**
   - **As a user, I want to view a list of all customers.**
   - `GET /customers`
   - *Response*: Array of customer objects.

3. **Retrieve a Single Customer**
   - **As a user, I want to view details of a specific customer.**
   - `GET /customers/{customerId}`
   - *Response*: Customer object.

4. **Update a Customer**
   - **As a user, I want to update the details of a customer.**
   - `PUT /customers/{customerId}`
   - *Response*: Updated customer object.

#### Order Management:
5. **Retrieve All Orders of a Customer**
   - **As a user, I want to view all orders placed by a specific customer.**
   - `GET /orders?customerId=`
   - *Response*: Array of order objects.

6. **Retrieve a Single Order**
   - **As a user, I want to view details of a specific order.**
   - `GET /orders?orderId=`
   - *Response*: Order object.

7. **Create an Order for a Customer**
   - **As a user, I want to create an order for a specific customer.**
   - `POST /orders`
   - *Payload*: `{ "orderDetails": "Details about the order" }`
   - *Response*: Created order object.

#### Product and Brand Insights:
8. **View Most Popular Brands**
   - **As an employee, I want to view the most popular brands.**
   - `GET /brands/popular`
   - *Response*: Array of popular brands with order count.

9. **View Stock Levels**
   - **As an employee, I want to view stock levels of products.**
   - `GET /products/stock-levels`
   - *Response*: Array of products with stock levels.

10. **View Customer Orders**
    - **As an employee, I want to view all orders placed by a specific customer.**
    - `GET /customers/{customerId}/orders`
    - *Response*: Array of orders placed by the customer.

11. **View Own Orders**
    - **As a customer, I want to view all my orders.**
    - `GET /customers/me/orders`
    - *Response*: Array of orders placed by the logged-in customer.

### Frontend Components:

- **Customer Form**: Allows creation and update of customer information with fields for name and email.
- **Order Form**: Enables order creation for a selected customer with order detail fields and customer selection.
- **Customer List**: Displays all customers with clickable entries leading to detailed views for managing orders.
- **Product Stock Levels**: Presents product stock levels, requesting data from `GET /products/stock-levels`.
- **Popular Brands**: Showcases popular brands, requesting data from `GET /brands/popular`.
