---

# 📘 ELMapper.NET

Lightweight .NET object mapper for object-to-object and collection mapping.

---

## 🚀 Overview

ELMapper.NET is a simple and fast .NET object mapper that uses reflection to map between objects at runtime.

It is designed for **predictable and explicit mapping behavior** with no silent mapping rules.

---

## ⚙️ Features

- Object → Object mapping
- Collection mapping
- Case-insensitive property matching
- Runtime property exclusion (Ignore)
- Fail-fast validation of configuration
- Lightweight (no external dependencies)

---

## 📦 Installation

```bash
dotnet add package ELMapper.NET
🚀 Usage
Default mapping
await context.BankEmployees.ToList()
    .MapIEnumerableAsync<BankEmployee, BankEmployeeVM>();
Mapping with options
await context.BankEmployees.ToList()
    .MapIEnumerableAsync<BankEmployee, BankEmployeeVM>(
        new MappingOptions
        {
            Ignore = new List<string> { "LastName" }
        });
Mapping with multiple ignored properties
await context.BankEmployees.ToList()
    .MapIEnumerableAsync<BankEmployee, BankEmployeeVM>(
        new MappingOptions
        {
            Ignore = new List<string> { "UserType", "LastName" }
        });
🔄 Mapping Behavior
✔ Property Matching
Properties are matched by name
Matching is case-insensitive
Only matching properties are mapped
✔ Ignore Feature
Properties listed in Ignore are excluded from mapping
Ignore properties must exist in source type
Invalid configuration throws exception (fail-fast behavior)
⚠️ Execution Model
Works only on in-memory objects
Does not support IQueryable projection
Mapping is performed using reflection
🧠 Design Philosophy
✔ Predictable behavior
✔ Fail-fast validation
✔ No silent mapping rules
✔ Simple and transparent design
📄 License

This project is licensed under the MIT License.

Copyright (c) 2026 Elvis Hodzic

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files, to deal in the Software without restriction.

🔗 Repository

https://github.com/YOUR_USERNAME/ELMapper.NET