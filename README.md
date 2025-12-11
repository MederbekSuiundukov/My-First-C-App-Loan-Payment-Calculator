# **Loan Payment Calculator (Console App)**

Loan Payment Calculator is a C# console application that demonstrates core programming concepts: **OOP, arrays, strings, loops, conditionals, mathematical logic, and file handling**.
The app calculates monthly loan payments and generates a full amortization schedule with CSV export.

---

## **1. Key Features**

* Calculates monthly annuity payments
* Shows total paid amount and total interest
* Displays first 6 months of the repayment schedule
* Saves data into CSV files:

  * `loans_summary.csv` — loan summary
  * `loan_schedule.csv` — full amortization table
* Supports multiple loans (data is appended, not overwritten)

---

## **2. C# Concepts Demonstrated**

* **OOP**: `Loan`, `Payment`, `LoanFileStorage`, `Program`
* **Arrays**: amortization stored in `Payment[]`
* **String formatting** (CSV output)
* **Loops** (`for`, `while`)
* **Conditionals** (`if/else`)
* **File handling** (`File`, `StreamWriter`)
* **Mathematical logic** for financial calculations

---

## **3. Project Structure**

```
MyFirstC#App/
 ├── main.cs<img width="581" height="175" alt="Снимок экрана 2025-12-11 в 20 14 41" src="https://github.com/user-attachments/assets/2efa7378-e04f-4bf5-b9bf-9907d9fb0303" />

 ├── loans_summary.csv
 ├── loan_schedule.csv
 └── README.md
```

---

## **4. How the  System Works**
## Command 1 (add new loan)
<img width="597" height="346" alt="Снимок экрана 2025-12-11 в 20 09 55" src="https://github.com/user-attachments/assets/f67161d0-ddec-499e-bcf1-58426790cd27" />

we write name , amount ,rate and term. After we get:
* Monthly payment
* Total paid
* Total interest

Show first 6 months?
Show monthly payments. 
Save full schedule?
Sawing in csv.


---
## Command 2 (show where located our csv files)
![Uploading Снимок экрана 2025-12-11 в 20.14.41.png…]()




