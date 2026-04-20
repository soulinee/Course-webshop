


# 📚 CourseMarketplace

A full-stack course marketplace application demonstrating a modern web architecture with a clear separation between frontend and backend, secure authentication, and a complete checkout flow.

---

## 🚀 Features

- 🔍 Course browsing & search  
- 📄 Pagination & filtering  
- 🛒 Shopping cart system  
- 💳 Stripe checkout integration  
- 🔐 Authentication (OIDC / Entra ID)  
- 📦 Order processing & enrollments  
- 📊 User dashboard with purchased courses  
- ✅ Form validation (Formik + Yup)  

---

## 🏗️ Architecture


### Key Principles
- Separation of concerns  
- RESTful API design  
- Scalable & maintainable structure  
- Frontend = UI + state  
- Backend = business logic  

---

## 🖥️ Tech Stack

### Frontend
- React + Vite  
- TypeScript  
- React Router  
- Context API  
- Formik + Yup  
- React Hot Toast  

### Backend
- .NET (C#)  
- REST API  
- Cosmos DB  
- Stripe API  
- OIDC Authentication  

---

## 🔄 Application Flow

### 1. Browse Courses
- Courses are fetched from the backend  
- Supports filtering and pagination  

### 2. Add to Cart
- Stored in frontend state (React Context)  

### 3. Checkout
- Cart items are sent to backend  
- Stripe session is created  

### 4. Payment Success
- Frontend calls `/api/checkout/confirm`  
- Backend creates enrollments  

### 5. Dashboard
- User sees purchased courses via `/api/courses/my`  

---

## 📦 Installation

### 1. Clone repository

```bash
git clone https://github.com/your-username/coursemarketplace.git
cd coursemarketplace
