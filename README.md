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

---
we write name , amount ,rate and term. After we get:
* Monthly payment
* Total paid
* Total interest

Show first 6 months?    Show monthly payments. 

Save full schedule?    Sawing in csv.


in CSV:

<img width="593" height="556" alt="Снимок экрана 2025-12-11 в 20 10 28" src="https://github.com/user-attachments/assets/2583a3da-447e-426e-b061-ac25e998a9e2" />

---

I check Zerotest:

<img width="613" height="401" alt="Снимок экрана 2025-12-11 в 20 12 54" src="https://github.com/user-attachments/assets/5aefccc9-93e4-437f-b1a2-d4a38a56169b" />

---

Also we may not save in csv

<img width="327" height="303" alt="Снимок экрана 2025-12-11 в 20 14 02" src="https://github.com/user-attachments/assets/9b5f83ca-036a-4fbf-949c-4108107fef2e" />

---
Summory csv:

<img width="284" height="77" alt="Снимок экрана 2025-12-11 в 20 16 30" src="https://github.com/user-attachments/assets/cdbd0baa-2c37-4bc6-a8a5-54b4a4707eef" />

---

## Command 2 (show where located our csv files)

<img width="581" height="175" alt="Снимок экрана 2025-12-11 в 20 14 41" src="https://github.com/user-attachments/assets/861a8bc5-52f2-41c1-b167-077cf002120e" />

---

## Command 3 (Exit)

<img width="284" height="77" alt="Снимок экрана 2025-12-11 в 20 16 30" src="https://github.com/user-attachments/assets/9b674125-f509-40ad-ba77-88a3551d8a97" />



## **4. How the System Works**

### **Command 1 — Create a New Loan**

<img width="597" height="346" alt="Loan Input Screenshot" src="https://github.com/user-attachments/assets/f67161d0-ddec-499e-bcf1-58426790cd27" />

When the user selects **Create new loan**, they are asked to enter:

* Loan name
* Principal amount
* Annual interest rate
* Loan term (years)

After providing the input, the system automatically calculates and displays:

* **Monthly payment**
* **Total paid**
* **Total interest**

The user may then choose:

* **Show first 6 months?** — displays the first six amortization rows
* **Save full schedule?** — appends the complete loan schedule to a CSV file

Example of schedule stored in CSV:

<img width="593" height="556" alt="CSV File Screenshot" src="https://github.com/user-attachments/assets/2583a3da-447e-426e-b061-ac25e998a9e2" />

---

### **Zero-Interest Test Case**

The system correctly handles a loan with **0% interest rate**:

<img width="613" height="401" alt="Zero Interest Screenshot" src="https://github.com/user-attachments/assets/5aefccc9-93e4-437f-b1a2-d4a38a56169b" />

---

### **Optional Schedule Saving**

Users may also choose **not** to save the schedule:

<img width="327" height="303" alt="Skip Saving Screenshot" src="https://github.com/user-attachments/assets/9b5f83ca-036a-4fbf-949c-4108107fef2e" />

---

### **Loan Summary CSV Example**

Each created loan is also added to a summary file:

<img width="284" height="77" alt="Summary CSV Screenshot" src="https://github.com/user-attachments/assets/cdbd0baa-2c37-4bc6-a8a5-54b4a4707eef" />

---

## **Command 2 — Show File Locations**

Displays absolute paths for both CSV files (summary and schedule):

<img width="581" height="175" alt="Path Output Screenshot" src="https://github.com/user-attachments/assets/861a8bc5-52f2-41c1-b167-077cf002120e" />

---

## **Command 3 — Exit Application**

Closes the program:

<img width="284" height="77" alt="Exit Screenshot" src="https://github.com/user-attachments/assets/9b674125-f509-40ad-ba77-88b3551d8a97" />




