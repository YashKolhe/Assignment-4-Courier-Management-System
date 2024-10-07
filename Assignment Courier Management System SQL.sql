create database Courier_Management_System
use Courier_Management_System

create table Users(
UserID INT PRIMARY KEY,  
Name VARCHAR(255),  
Email VARCHAR(255) UNIQUE, 
Password VARCHAR(255),  
ContactNumber VARCHAR(20),  
Address TEXT  
)
insert into Users
(UserID,Name,Email,Password,ContactNumber,Address)
values
(01,'Sachin','sachin123@gmail.com','sachin123','1111111111','Mumbai'),
(02,'Virat','virat123@gmail.com','virat123','2222222222','Delhi'),
(03,'Rohit','rohit123@gmail.com','rohit123','3333333333','Nagpur'),
(04,'Rahul','rahul123@gmail.com','rahul123','4444444444','Banglore'),
(05,'Dhoni','dhoni123@gmail.com','dhoni123','5555555555','Ranchi'),
(06,'Shami','shami123@gmail.com','shami123','6666666666','Mumbai'),
(07,'Siraj','siraj123@gmail.com','siraj123','7777777777','Hyderabad'),
(08,'Jassi','jassi123@gmail.com','jassi123','8888888888','Banglore')

select* from Users

create table Couriers  
(CourierID INT PRIMARY KEY,  
SenderName VARCHAR(255),  
SenderAddress TEXT,  
ReceiverName VARCHAR(255),  
ReceiverAddress TEXT,  
Weight DECIMAL(5, 2),  
Status VARCHAR(50),  
TrackingNumber VARCHAR(20) UNIQUE,  
DeliveryDate DATE) 
alter table Couriers
alter column SenderAddress varchar(255)
alter table Couriers
alter column ReceiverAddress varchar(255)
ALTER TABLE Couriers
alter column DeliveryDate Datetime;

alter table Couriers
add EmployeeID int
update Couriers
set EmployeeID = 1 
where CourierID in (1,4)
update Couriers
set EmployeeID = 2
where CourierID in (6,8)
update Couriers
set EmployeeID =5 
where CourierID = 3
update Couriers
set EmployeeID = 7 
where CourierID = 2
update Couriers
set EmployeeID = 8 
where CourierID in (5,7)
alter table Couriers
add ServiceID int
update Couriers
set ServiceID = 1
where CourierID in (3,8)
update Couriers
set ServiceID = 2
where CourierID in (1,7)
update Couriers
set ServiceID = 3
where CourierID in (4,6)
update Couriers
set ServiceID = 5
where CourierID = 2

insert into Couriers
(CourierID,SenderName,SenderAddress,ReceiverName,ReceiverAddress,Weight,Status,TrackingNumber,DeliveryDate)
values
(1,'Sachin','Mumbai','Virat','Delhi',27.88,'Dispatched','110','2024-10-20'),
(2,'Virat','Delhi','Rohit','Nagpur',23.88,'Delivered','220','2024-10-10'),
(3,'Sachin','Mumbai','Jassi','Banglore',37.88,'Preparing','330','2024-10-25'),
(4,'Shami','Mumbai','Dhoni','Ranchi',47.88,'Delivered','440','2024-10-10'),
(5,'Rahul','Banglore','Siraj','Hyderabad',43.88,'Dispatched','550','2024-10-19'),
(6,'Dhoni','Ranchi','Rahul','Banglore',33.88,'Delivered','660','2024-10-09'),
(7,'Siraj','Hyderabad','Sachin','Mumbai',17.88,'Dispatched','770','2024-10-18'),
(8,'Virat','Delhi','Shami','Mumbai',25.88,'Preparing','880','2024-10-24')
select * from Couriers

create table CourierServices  
(ServiceID INT PRIMARY KEY,  
ServiceName VARCHAR(100),  
Cost DECIMAL(8, 2))

insert into CourierServices
(ServiceID,ServiceName,Cost)
values
(1,'DTDC',60000),
(2,'Blink',30000),
(3,'Transit',50000),
(4,'Canvas',80000),
(5,'Starline',10000)
select* from CourierServices
create table Employee
(EmployeeID INT PRIMARY KEY,  
Name VARCHAR(255),  
Email VARCHAR(255) UNIQUE,  
ContactNumber VARCHAR(20),  
Role VARCHAR(50),  
Salary DECIMAL(10, 2))

insert into Employee
values
(01,'Yash','yash123@gmail.com','1231231231','Manager',80000),
(02,'Saurabh','saurabh123@gmail.com','2323232323','Courier',30000),
(03,'Shivam','shivam123@gmail.com','3434343434','Courier',40000),
(04,'Adarsh','adarsh123@gmail.com','4545454545','Packaging',30000),
(05,'Mohit','mohit123@gmail.com','6767676767','Courier',40000),
(06,'Ram','ram23@gmail.com','1234123412','Packaging',80000),
(07,'Lucky','lucky123@gmail.com','8989898989','Courier',80000),
(08,'Rocky','rocky123@gmail.com','9898989898','Courier',30000)
select * from Employee
create table Locations  
(LocationID INT PRIMARY KEY,  
LocationName VARCHAR(100),  
Address TEXT)
alter table Locations
alter column Address varchar(255)

insert into Locations
values
(1,'CityA','Delhi'),
(2,'CityB','Nagpur'),
(3,'Cityc','Banglore'),
(4,'CityD','Ranchi'),
(5,'CityE','Hyderabad')
select* from Locations
create table Payments 
(PaymentID INT PRIMARY KEY,  
CourierID INT,  
LocationId INT,  
Amount DECIMAL(10, 2),  
PaymentDate DATE,  
FOREIGN KEY (CourierID) REFERENCES Couriers(CourierID),  
FOREIGN KEY (LocationID) REFERENCES Locations(LocationID))

insert into Payments
values
(1,1,3,25000,'2024-09-25'),
(2,4,2,65000,'2022-06-25'),
(3,3,2,15000,'2023-09-25'),
(4,8,1,25000,'2021-02-25'),
(5,4,4,55000,'2022-11-25'),
(6,6,1,35000,'2023-08-25'),
(7,2,5,65000,'2024-10-25')
select* from Payments

--Q1 List all customers
select* from Users

--Q2 . List all orders for a specific customer: 
select* from Couriers
where SenderName = 'virat'
--Q3 List all couriers
select* from Couriers

--Q4 List all packages for a specific order
  select * from Couriers where TrackingNumber = 660

--Q5 5. List all deliveries for a specific courier:  
 select* 
 from Couriers where receivername = 'rohit'

--6. List all undelivered packages:  
select * from Couriers
where Status = 'Preparing'

--7. List all packages that are scheduled for delivery today:  
select * from Couriers
where status = 'Dispatched'

--8. List all packages with a specific status:  
select * from Couriers
where status = 'Delivered'

--9. 9. Calculate the total number of packages for each courier.  
select SenderName, count(*) as totalpackages 
from Couriers
group by SenderName
--10. Find the average delivery time for each courier  
select SenderName, avg(datediff(day, DeliveryDate,'2024-11-01' )) as AverageDeliveryTime
from Couriers
group by 
    SenderName;
--11. List all packages with a specific weight range:  
select * from Couriers
where Weight between 10 and 40

--12. Retrieve employees whose names contain 'Yash
select * from Employee
where name like '%Yash%'

--Q13. 13. Retrieve all courier records with payments greater than 30000.
select* 
from Couriers as c
join Payments as p on c.CourierID = p.CourierID
where p.Amount > 30000

--Q14 14. Find the total number of couriers handled by each employee.  
select e.Name as EmployeeName, count(c.CourierID) as TotalCouriers
from Employee e
left join Couriers c on e.EmployeeID = c.EmployeeID
group by e.EmployeeID, e.Name;

--Q 15. Calculate the total revenue generated by each location  
select L.LocationName , sum(p.Amount) as Revenue_generated
from Locations as L
join Payments as p on L.LocationID = p.LocationId
group by L.LocationName

--Q 16. Find the total number of couriers delivered to each location.  
select L.Address, count(c.CourierID)
from Locations as L
left join Couriers as c on L.Address = c.ReceiverAddress
group by L.Address

--Q 17. Find the courier with the highest average delivery time:  
select  c.SenderName,c.ReceiverName,c.CourierID, avg(datediff(day,c.DeliveryDate,2024-11-01))as avgdeliverytime
from Couriers as c
group by c.CourierID,c.SenderName,c.ReceiverName
order by avgdeliverytime desc

--Q 18. Find Locations with Total Payments Less Than a Certain Amount  
select L.LocationName , sum(p.Amount) as Revenue_generated
from Locations as L
join Payments as p on L.LocationID = p.LocationId
group by L.LocationName
having sum(p.Amount) < 65000

--Q 19. Calculate Total Payments per Location  
select p.LocationId, L.LocationName, sum(p.Amount)
from Payments as p
left join Locations as L on p.LocationID = L.LocationID
group by p.LocationID,L.LocationName

--Q20 Retrieve couriers who received payments totaling more than 10000 in a specific location(LocationID = X):
select c.CourierID,c.SenderName,c.ReceiverName , sum(p.amount) as totalpayment
from Couriers as c 
join Payments as p on c.CourierID = p.CourierID
where p.LocationId= 2
group by  c.CourierID, c.SenderName,c.ReceiverName
having sum(p.amount)>10000

--Q21 Retrieve couriers who have received payments totaling more than 10000 after a certain date (PaymentDate > 'YYYY-MM-DD'): 
select c.CourierID,c.SenderName,c.ReceiverName , p.PaymentDate, sum(p.amount) as totalpayment
from Couriers as c 
join Payments as p on c.CourierID = p.CourierID
where p.PaymentDate > '2023-08-24' 
group by  c.CourierID, c.SenderName,c.ReceiverName, p.PaymentDate
having sum(p.amount) > 20000

--Q 22. Retrieve locations where total amount received is more than 55000 before a certain date (PaymentDate > 'YYYY-MM-DD') 
select L.LocationName, sum(p.Amount) as totalamount
from Payments as p
join Locations as L on p.LocationId = L.LocationID
where p.PaymentDate < '2023-08-26'
group by L.LocationName
having sum(p.amount) > 55000

--Q 23. Retrieve Payments with Courier Information  
select p.PaymentID, c.CourierID,c.SenderName,c.ReceiverName,p.Amount,p.PaymentDate,c.Status,c.DeliveryDate,c.TrackingNumber,c.Weight
from Payments as p
join Couriers as c on p.CourierID = c.CourierID
group by p.PaymentID, c.CourierID,c.SenderName,c.ReceiverName,p.Amount,p.PaymentDate,c.Status,c.DeliveryDate,c.TrackingNumber,c.Weight

--Q 24. Retrieve Payments with Location Information  
select p.PaymentID,p.LocationId,L.LocationName,p.PaymentDate,p.Amount
from Payments as p
join Locations as L on p.LocationId = L.LocationID
group by p.PaymentID,p.LocationId,L.LocationName,p.PaymentDate,p.Amount

--Q 25. Retrieve Payments with Courier and Location Information  
select p.PaymentID,p.Amount,p.PaymentDate,c.SenderName,c.ReceiverName,l.LocationName
FROM Payments p
JOIN Couriers c ON p.CourierID = c.CourierID
JOIN Locations l ON p.LocationId = l.LocationID;

--Q 26. List all payments with courier details  
select P.PaymentID,c.SenderName,c.SenderAddress,c.ReceiverName,c.ReceiverAddress,c.DeliveryDate,p.Amount
from Payments as p
join Couriers as c on p.CourierID=c.CourierID

--Q 27. Total payments received for each courier  
select c.CourierID, sum(p.amount) as paymentReceived
from Couriers as c
left join Payments as p on c.CourierID = p.CourierID
group by c.CourierID

--Q 28. List payments made on a specific date  
select *
from Payments as p
where PaymentDate = '2022-06-25'

--Q 29. Get Courier Information for Each Payment  
select *
from payments as p
left join Couriers as c on p.CourierID = c.CourierID

--Q 30. Get Payment Details with Location  
select *
from Payments as p
left join Locations as L on p.LocationId = l.LocationID

--Q 31. Calculating Total Payments for Each Courier  
select c.CourierID, sum(p.amount)
from Couriers as c
left join Payments as p on c.CourierID = p.CourierID
group by c.CourierID

--Q 32. List Payments Within a Date Range  
select *
from Payments
where PaymentDate between '2022-06-20' and '2023-08-26'

--Q 33. Retrieve a list of all users and their corresponding courier records, including cases where there are no matches on either side 
select u.Name, c.CourierID
from users as u 
full outer join couriers as c on u.Name = c.SenderName

--Q 34. Retrieve a list of all couriers and their corresponding services, including cases where there are no matches on either side 
select c.CourierID,c.SenderName,c.ReceiverName,cs.ServiceName,cs.Cost
from couriers as c
full outer join CourierServices as cs on c.ServiceID = cs.ServiceID

--Q 35. Retrieve list of all employees and their corresponding payments, including cases where there are no matches on either side 
select e.Name as EmployeeName , p.PaymentID, p.Amount
from Employee as e 
full outer join Payments as p on e.EmployeeID = p.CourierID

--Q 36. List all users and all courier services, showing all possible combinations.  
select u.UserID,u.Name as UserName, cs.ServiceID,cs.ServiceName,cs.Cost
from users as u 
cross join CourierServices as cs

--Q 37. List all employees and all locations, showing all possible combinations:  
select e.EmployeeID, e.Name as EmployeeName,l.LocationID,l.LocationName,l.Address
from Employee as e 
cross join Locations as l

--Q 38. Retrieve a list of couriers and their corresponding sender information (if available)  
select c.CourierID,c.SenderName,u.Name AS SenderFullName,u.Email AS SenderEmail,u.ContactNumber AS SenderContactNumber,u.Address AS SenderAddress,c.ReceiverName,c.ReceiverAddress,c.Weight,c.Status,c.TrackingNumber,c.DeliveryDate
from Couriers c
join Users u on c.SenderName = u.Name

--Q 39. Retrieve a list of couriers and their corresponding receiver information (if available):  

select c.CourierID,c.ReceiverName,u.Name AS ReceiverFullName,u.Email AS ReceiverEmail,u.ContactNumber AS ReceiverContactNumber,u.Address AS ReceiverAddress,c.SenderName,c.SenderAddress,c.Weight,c.Status,c.TrackingNumber,c.DeliveryDate
from Couriers c
join Users u on c.ReceiverName = u.Name;

--Q 40. Retrieve a list of couriers along with the courier service details (if available):  
select c.CourierID,c.ServiceID,c.SenderName,c.ReceiverName,cs.ServiceName,cs.Cost
from Couriers as c
join CourierServices as cs on c.ServiceId = cs.ServiceID

--Q 41. Retrieve a list of employees and the number of couriers assigned to each employee:  
select e.EmployeeID,e.Name as EmployeeName,count(c.CourierID) as CouriersAssigned
from Employee as e
left join Couriers as c on e.EmployeeID = c.EmployeeID
group by e.EmployeeID,e.Name

--Q 42. Retrieve a list of locations and the total payment amount received at each location:  
select L.LocationID,L.LocationName, sum(p.amount)
from Locations as L 
left join Payments as p on L.LocationID = p.LocationId
group by L.LocationID,L.LocationName

--Q 43. Retrieve all couriers sent by the same sender (based on SenderName).  
select c1.SenderName,c1.CourierID,c1.ReceiverName,c1.ReceiverAddress,c1.Weight,c1.Status,c1.TrackingNumber,c1.DeliveryDate
from Couriers c1
join Couriers c2 ON c1.SenderName = c2.SenderName AND c1.CourierID < c2.CourierID
order by c1.SenderName, c1.CourierID

--Q 44. List all employees who share the same role.  
select e1.EmployeeID,e1.Name as EmployeeName,e2.EmployeeID as EmployeeName,e2.Name, e1.Role
from Employee as e1
join Employee as e2 on e1.Role=e2.Role and e1.EmployeeId<e2.EmployeeID

--Q 45. Retrieve all payments made for couriers sent from the same location.  
select p.PaymentID,L.LocationID,L.LocationName,c.SenderName,c.ReceiverName,p.Amount,p.PaymentDate
from Payments as p
join Couriers as c on p.CourierID = c.CourierID
join Locations as L on p.LocationId = L.LocationID
where L.LocationID in( select L.LocationID
                        from Locations as L
						join Payments as p on L.LocationID = p.LocationId
						group by L.LocationID
						having count(*)>1)
order by L.LocationName,p.PaymentID

--Q 46. Retrieve all couriers sent from the same location (based on SenderAddress).  
select c1.CourierID,c1.SenderName,c1.SenderAddress,c2.CourierID,c2.SenderName,c2.SenderAddress
from couriers as c1
join couriers as c2 on c1.SenderAddress=c2.SenderAddress and c1.CourierID<c2.CourierID

--Q 47. List employees and the number of couriers they have delivered:  
select e.EmployeeID,e.Name as EmployeeName, count(c.CourierID) as CouriersDelivered
from Employee as e
left join Couriers as c on e.EmployeeID = c.EmployeeID
where c.Status = 'Delivered'
group by e.EmployeeID,e.Name,c.status

--Q48 Find couriers that were paid an amount greater than cost of their respective courier services  
select c.CourierID,c.SenderName,c.ReceiverName,cs.ServiceName,p.amount as CourierAmount, cs.Cost as ServiceCharge
from Couriers as c
join Payments as p on c.CourierID = p.CourierID
join CourierServices as cs on c.ServiceID = cs.ServiceID
where p.amount > cs.Cost

--Q49. Find couriers that have a weight greater than the average weight of all couriers  
select CourierID,SenderName,ReceiverName,weight
from couriers 
where weight > ( select avg(weight) from couriers)

--Q 50. Find the names of all employees who have a salary greater than the average salary: 
select Name as EmployeeName, Salary
from Employee 
where salary > (select avg(salary) from Employee)

--Q51. Find the total cost of all courier services where the cost is less than the maximum cost  
select sum(Cost) as TotalCost
from CourierServices
where Cost < (select max(Cost) from CourierServices)

--Q52. Find all couriers that have been paid for  
select * 
from Couriers
where CourierID in (select CourierID from Payments)

--Q 53. Find the locations where the maximum payment amount was made  
select l.LocationName,p.Amount
from Locations as l
join payments as p on l.LocationID = p.LocationID
where p.Amount =  (select max(amount) from Payments)

--Q54 Find all couriers whose weight is greater than weight of all couriers sent by specific sender(eg 'SenderName') 
select SenderName,ReceiverAddress,Weight
from Couriers 
where weight>(select max(weight) from couriers
                  where SenderName = 'Virat')
