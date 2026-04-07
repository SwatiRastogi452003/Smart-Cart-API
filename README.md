# Smart-Cart-API
Building a simplified e-commerce checkout system for an online store. Customers can browse a product list, add items to cart, apply coupons, and place an order. The system must ensure pricing correctness and prevent inconsistent checkout outcomes.
SmartCart-FullStack/
│
├─ backend/SmartCart.Api/
│   ├─ Controllers/
│   │   ├─ ProductsController.cs
│   │   ├─ CartController.cs
│   │   └─ OrdersController.cs
│   ├─ Services/
│   │   ├─ ProductService.cs
│   │   ├─ CartService.cs
│   │   └─ OrderService.cs
│   ├─ Repositories/
│   │   ├─ ProductRepository.cs
│   │   ├─ CartRepository.cs
│   │   └─ OrderRepository.cs
│   ├─ Models/
│   │   ├─ Product.cs
│   │   ├─ CartItem.cs
│   │   ├─ Cart.cs
│   │   ├─ Coupon.cs
│   │   └─ Order.cs
│   ├─ DTOs/
│   │   ├─ AddCartItemDto.cs
│   │   ├─ ApplyCouponDto.cs
│   │   └─ CheckoutResponseDto.cs
│   ├─ Program.cs
│   ├─ appsettings.json
│   └─ SmartCart.Api.csproj
│
├─ frontend/smartcart-frontend/
│   ├─ src/
│   │   ├─ pages/
│   │   │   ├─ CartPage.js
│   │   │   ├─ OrderSuccess.js
│   │   │   └─ ProductsPage.js
│   │   ├
│   │   │└─ api.js   
│   │   ├─ App.jsx
│   │   └─ index.js
│   ├─ package.json
│   └─ public/index.html
│
└

---

# README.txt

# Smart Cart & Coupon Checkout (Full Stack)

## Backend Setup (C# .NET 8)

1. Navigate to backend folder:

   ```bash
   cd backend/SmartCart.Api
   ```

2. Restore dependencies and build:

   ```bash
   dotnet restore
   dotnet build
   ```

3. Run the API:

   ```bash
   dotnet run
   ```

4. Access Swagger UI at: `https://localhost:5001/swagger`

## Frontend Setup (React)

1. Navigate to frontend folder:

   ```bash
   cd frontend/smartcart-frontend
   ```

2. Install dependencies:

   ```bash
   npm install
   ```

3. Start development server:

   ```bash
   npm start
   ```

4. The app should run at: `http://localhost:3000`

## Features

* View product list
* Add/update cart items
* Apply coupons (FLAT50, SAVE10)
* Checkout with atomic stock reduction
* Order summary with subtotal, discount, total

## Tests

* Unit tests can be added under `backend/SmartCart.Api.Tests` project
* Example tests:

  * Coupon validation
  * Checkout pricing
  * Stock error handling
   
