-- Customer Data (1 customer)
INSERT INTO dbo.Customers (FirstName, LastName, Email, Phone, DeliveryAddress, PostalCode, City, Country)
VALUES ('John', 'Doe', 'john.doe@example.com', '555-123-4567', '123 Main Street', '12345', 'New York', 'USA');

-- Categories (3 categories)
INSERT INTO dbo.Categories (Name)
VALUES 
('Clothing'),
('Electronics'),
('HomeKitchen');

-- Products (2 products per category)
-- NOTE: Make sure to insert products after inserting categories
-- Clothing Products (Category 1)
INSERT INTO dbo.Products (Title, Description, Price, StockQuantity, ImageURL, CategoryID)
VALUES 
('T-Shirt', 'Cotton t-shirt in various colors', 19.99, 100, 'https://images.unsplash.com/photo-1579109015395-eb2bf0fa095e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 1),
('Jeans', 'Classic blue denim jeans', 49.99, 50, 'https://images.unsplash.com/photo-1542272604-787c3835535d?q=80&w=1926&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 1);

-- Electronics Products (Category 2)
INSERT INTO dbo.Products (Title, Description, Price, StockQuantity, ImageURL, CategoryID)
VALUES 
('Smartphone', 'Latest model smartphone with high-resolution camera', 699.99, 30, 'https://images.unsplash.com/photo-1610945265064-0e34e5519bbf?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 2),
('Headphones', 'Wireless noise-cancelling headphones', 149.99, 45, 'https://images.unsplash.com/photo-1609081219090-a6d81d3085bf?q=80&w=1926&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 2);

-- HomeKitchen Products (Category 3)
INSERT INTO dbo.Products (Title, Description, Price, StockQuantity, ImageURL, CategoryID)
VALUES 
('Coffee Maker', 'Programmable coffee maker with timer', 79.99, 25, 'https://images.unsplash.com/photo-1545936055-22b27770efca?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 3),
('Knife Set', 'Professional 8-piece kitchen knife set', 129.99, 15, 'https://images.unsplash.com/photo-1507648154934-f230d5bd6942?q=80&w=1995&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 3);