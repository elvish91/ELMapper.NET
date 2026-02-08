ELMapper.NET - a solution for automatic mapping of objects and collections. It is necessary to define at least some properties from the source class to the destination with the same names in the source class. The Mapper works in two ways (object-to-object mapping and collection-to-collection mapping) using four methods that work in asynchronous and synchronous modes.
These are the generic extension methods used (the suffix Async is for asynchronous methods):
1. MapObjectAsync<T_Source, T_Destination>(T_Destination? objTo = null)
2. MapObject<T_Source, T_Destination>(T_Destination? objTo = null)
3. Task<IEnumerable<T_Destination>>
MapIEnumerableAsync<T_Source, T_Destination>(List<T_Destination>? listTo=null)
4. IEnumerable<T_Destination> MapIEnumerable<T_Source, T_Destination>(List<T_Destination>? listTo = null)

Since the methods are extension methods, the source is the object from which we call the method itself, and it is also important to specify the types for the source and destination as in the method signatures above.
Each method has an optional parameter to which we pass an object or a generic list (often the case is that we have a ViewModel object with properties that have already set values).
The method's return type is the destination type as shown above, with the exception that for generic collections the return type is IEnumerable.

Below are examples of calling asynchronous methods from the controller action where the source is BankEmployee and the destination is BankEmployeeVM:

1. Mapping collections without passing an optional parameter: 
   
   await context.BankEmployees.ToList().MapIEnumerableAsync<BankEmployee, BankEmployeeVM>();

2. Collection mapping with optional parameter passing
   List<BankEmployeeVM> destList /*assumption that here we already have the property values ​​of the BankEmployeeVM class set, but that these properties are not on the source, so that we do not lose the property values ​​that are on the objects of the BankEmployeeVM class*/
    context.BankEmployees.ToList().MapIEnumerable<BankEmployee, BankEmployeeVM>(destList);

3. Mapping object to object without passing an optional parameter:

   await context.BankEmployees.Where(x=>x.Id==id).FirstAsync().Result.MapObjectAsync<BankEmployee,BankEmployeeVM>()


4. Object-to-object mapping with optional parameter passing:
   BankEmployeeVM destObj /*assumption that here we already have set property values ​​of the BankEmployeeVM class and that those properties are not located on the source so that we do not lose the property values ​​that are on the objects of the BankEmployeeVM class*/
  await context.BankEmployees.Where(x=>x.Id==id).FirstAsync().Result.MapObjectAsync<BankEmployee,BankEmployeeVM>(destObj)

5. In addition to asynchronous methods, we also have synchronous ones, so we will give one example of object-to-object mapping (all synchronous methods are called in the same way - without the suffix Async as stated above in signatures):
context.BankEmployees.Where(x=>x.Id==id).First().MapObject<BankEmployee,BankEmployeeVM>();