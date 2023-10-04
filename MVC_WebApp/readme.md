# USing EF 

- ctx is an instance of DbCOntext
- Employee is an Entity class
````html
- DbSet<Employee> is Employees
````


- TO Read all Records
````csharp
	var result = ctx.Employees.ToList();
````

- TO Read a record based in Primary Key
````csharp
  var result = ctx.Employees.Find(PRIMARY-KEY-VALUE);
````

- To Add a New record
````csharp
// 1. CReate an instnace of Entity class
EMployee emp = new Employee();
// 2. Set its property values
emp.EMpNo=100;
......

// 3. Add the record in DbSet
ctx.Employees.Add(emp);

// 4. COmmit Trnasaction
ctx.SaveChanges();
````

- TO Add Multiple Records

````csharp
// 1. CReate a List   of Entity class
List<EMployee> emps = new Employee();
// 2. Add EMployees in List
emps.Add(new EMployee(){.....})
// 3. Add the record in DbSet
ctx.Employees.AddRange(emps);

// 4. COmmit Trnasaction
ctx.SaveChanges();
```` 

- Deleting a record
````csharp
// 1. Search record based on Primary Key
// 2. PAss the Record to Remove Method
ctx.Employees.Remove(emp);
// 3. COmmit Transaction
ctx.SaveChanges()
````

- Update a record
````csharp
// 1. Search record based on Primary Key
// 2. Update property values for searched record
emp.EMpNAme= "kjdfhfk;aj"
// 3. COmmit Transaction
ctx.SaveChanges()
````

