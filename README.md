# KrishiBazaarProject
Krishi Bazaar — Local Farmer Marketplace

A full-stack agricultural marketplace that connects farmers directly with buyers, enabling transparent pricing, efficient order management, and structured logistics through a hub-based delivery network.

The platform eliminates traditional middlemen by allowing farmers to sell products directly to consumers while the system manages product listings, orders, payments, logistics routing, messaging, and reviews.

Developed using .NET / ASP.NET with C# and SQL Server in Visual Studio 2022.

Table of Contents

Overview

System Features

System Architecture

Logistics Model

Database Design

System Modules

Technology Stack

Project Structure

Installation Guide

Screenshots

Future Improvements

Contributors

License

Overview

Agricultural supply chains often suffer from inefficiencies caused by intermediaries, lack of price transparency, and poor logistics coordination. Krishi Bazaar addresses these problems by providing a digital marketplace where farmers can list their products and buyers can place orders directly.

The system integrates commerce functionality with a structured logistics pipeline that routes orders through secondary hubs and primary hubs before final delivery.

The system workflow includes:

Farmer registers and uploads agricultural products

Buyers browse and purchase products

Orders are recorded and payment is processed

Admin assigns delivery hubs based on location

Products move through the hub network

Last-mile delivery completes the order

Buyers submit ratings and reviews

The platform also includes a messaging system, allowing buyers and farmers to communicate directly.

The complete data flow of the system was designed using structured diagrams described in the project documentation. 

A104

System Features
User Management

User registration and login

Role-based accounts (Buyer / Farmer)

Profile and address management

Secure authentication

Product Marketplace

Farmers can upload products

Product categories

Pricing and quantity management

Product descriptions and images

Order Management

Buyers can place orders

Order tracking

Quantity selection

Total price calculation

Payment Tracking

Transaction record per order

Payment method storage

Payment confirmation and status tracking

Messaging System

Direct communication between buyers and farmers

Message timestamps

Conversation history

Review and Rating System

Buyers can review purchased products

Rating scores

Written feedback

Hub-Based Delivery System

Orders move through a structured logistics pipeline:

Seller → Local Secondary Hub → Regional Primary Hub → Destination Primary Hub → Local Secondary Hub → Buyer Delivery

This enables scalable distribution across cities.

System Architecture

The system consists of several interacting modules:

Module	Responsibility
User Management	Registration, authentication, profiles
Product Management	Product listings and inventory
Order Processing	Order creation and tracking
Payment System	Transaction management
Delivery System	Hub assignment and delivery tracking
Messaging	Buyer–seller communication
Review System	Product feedback
Logistics Model

Krishi Bazaar uses a multi-hub delivery architecture.

Secondary Hub

Local distribution center near the farmer or buyer.

Primary Hub

Major regional logistics center responsible for inter-city transfers.

Delivery Flow

Seller sends product to nearby Secondary Hub

Secondary hub forwards to Primary Hub

Primary hub performs inter-city transfer

Destination primary hub sends to buyer's Secondary Hub

Last-mile delivery completes the order

This design improves scalability and delivery coordination.
