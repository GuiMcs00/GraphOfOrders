# pip install SQLAlchemy
# pip install psycopg2-binary

from datetime import date
import random
from datetime import datetime
from sqlalchemy import create_engine, Column, Integer, String, ForeignKey, Date
from sqlalchemy.orm import declarative_base
from sqlalchemy.orm import relationship, sessionmaker

Base = declarative_base()

class Category(Base):
    __tablename__ = 'Categories'
    CategoryId = Column(Integer, primary_key=True)
    CategoryName = Column(String)
    products = relationship('Product', back_populates='category')

class Product(Base):
    __tablename__ = 'Products'
    ProductId = Column(Integer, primary_key=True)
    ProductName = Column(String)
    CategoryId = Column(Integer, ForeignKey('Categories.CategoryId'))
    category = relationship('Category', back_populates='products')
    brands = relationship('Brand', back_populates='product')

class Brand(Base):
    __tablename__ = 'Brands'
    BrandId = Column(Integer, primary_key=True)
    BrandName = Column(String)
    ProductId = Column(Integer, ForeignKey('Products.ProductId'))
    product = relationship('Product', back_populates='brands')
    orders = relationship('Order', back_populates='brand')

class Order(Base):
    __tablename__ = 'Orders'
    OrderId = Column(Integer, primary_key=True)
    BrandId = Column(Integer, ForeignKey('Brands.BrandId'))
    OrderDate = Column(Date)
    brand = relationship('Brand', back_populates='orders')

# Connect to the database
engine = create_engine('postgresql://postgres:changeme@170.83.132.66:5432/postgres')

# Bind the engine to the metadata of the Base class
Base.metadata.create_all(engine)

# Create a session
Session = sessionmaker(bind=engine)
session = Session()


# List of category names
category_names = [
    'Electronics', 
    'Clothing', 
    'Home Appliances', 
    'Groceries',
    'Automotive',
    'Health & Wellness',
    'Books & Stationery',
    'Toys & Games',
    'Furniture & Decor',
    'Sports & Outdoor'
]

for idx, cat_name in enumerate(category_names, start=1):
    category = Category(CategoryName=cat_name)
    session.add(category)
    print("category added")

    for p in range(1, 7):
        product_name = f'Product{p}_Cat{idx}'
        product = Product(ProductName=product_name, category=category)
        session.add(product)
        print("prodcut added")

        for b in range(1, 10):
            brand_name = f'Brand{b}_Prod{p}_Cat{idx}'
            brand = Brand(BrandName=brand_name, product=product)
            session.add(brand)
            print("brand added")

            for o in range(1, 30):
                random_month = random.randint(1, 4)
                random_day = random.randint(1, 28)
                order_date = date(2023, random_month, random_day)
                order = Order(brand=brand, OrderDate=order_date)
                session.add(order)
                print("order added")

    # Commit after inserting all records related to a category
    session.commit()
