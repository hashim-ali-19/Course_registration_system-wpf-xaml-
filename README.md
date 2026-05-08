# 🎓 Course Registration System — WPF Application

> A Windows desktop application built with **C# and WPF (Windows Presentation Foundation)** that allows students to register for programming courses and automatically calculates the total fee based on selected courses and skill level.

---

## 📋 Project Info

| Field | Details |
|---|---|
| **Student** | Hashim Ali |
| **Registration No.** | 247259 |
| **Course** | Visual Programming (Lab) |
| **Instructor** | Prof Qaiser Ali |
| **Submission Date** | 15 March 2026 |

---

## ✨ Features

- 📝 Enter student name
- ✅ Select one or more programming courses from a list
- 🎯 Choose skill level — Beginner, Intermediate, or Advanced
- 💰 Auto-calculate base fee, discount, and final payable fee
- 🔘 **Calculate**, **Reset**, and **Submit** buttons
- ⚠️ Input validation before submission

---

## 📚 Available Courses & Fees

| Course Name | Fee (Rs.) |
|---|---|
| C# Programming | Rs. 5,000 |
| Java Programming | Rs. 4,500 |
| JavaScript and Web Dev | Rs. 4,000 |
| Python Programming | Rs. 3,500 |
| Ruby on Rails | Rs. 6,000 |

---

## 🎯 Discount Structure

| Skill Level | Discount |
|---|---|
| Beginner | 0% |
| Intermediate | 10% |
| Advanced | 15% |

---

## 🛠️ Technologies Used

| Tool | Details |
|---|---|
| **IDE** | Microsoft Visual Studio (Community) |
| **Framework** | .NET Framework 4.8 / .NET 6+ |
| **Language** | C# |
| **UI Technology** | WPF — Windows Presentation Foundation |
| **Markup** | XAML |
| **Namespace** | `RegistrationApp` |
| **Target OS** | Windows 11 |

---

## 📸 Screenshots

> *(Add your screenshots here)*

```
![Default Load](screenshots/default.png)
![Fee Calculation](screenshots/calculation.png)
![Successful Submission](screenshots/submit.png)
```

---

## 🚀 Getting Started

### Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/) (Community or higher)
- .NET Framework 4.8 or .NET 6+

### Installation

1. **Clone the repository:**

```bash
git clone https://github.com/your-username/course-registration-wpf.git
```

2. **Open in Visual Studio:**
   - Go to `File → Open → Project/Solution`
   - Select the `.sln` file

3. **Build & Run:**
   - Press `F5` or click **Start**

---

## 📁 Project Structure

```
RegistrationApp/
│
├── MainWindow.xaml          # UI layout (XAML)
├── MainWindow.xaml.cs       # Code-behind (C# logic)
├── App.xaml                 # Application entry point
├── App.xaml.cs
└── README.md
```

---

## ⚙️ How It Works

### UI Controls

| Control | Name | Purpose |
|---|---|---|
| TextBox | `txtName` | Student name input |
| CheckBox ×5 | `chkCSharp`, `chkJava`, etc. | Course selection |
| RadioButton ×3 | `rbBeginner`, `rbIntermediate`, `rbAdvanced` | Skill level selection |
| TextBlock | `lblBaseFee` | Shows base fee |
| TextBlock | `lblDiscount` | Shows discount % |
| TextBlock | `lblDiscountAmount` | Shows discount amount |
| TextBlock | `lblTotalFee` | Shows final payable fee |
| Button | `btnCalculate` | Triggers fee calculation |
| Button | `btnReset` | Clears the form |
| Button | `btnSubmit` | Submits registration |

### Fee Calculation Logic (`CalculateFee()`)

1. Initialize `totalFee = 0`
2. For each checked course CheckBox → add that course's fee to `totalFee`
3. Determine `discountPercent` based on selected RadioButton (0 / 0.10 / 0.15)
4. `discountAmount = totalFee × discountPercent`
5. `finalFee = totalFee − discountAmount`
6. Update all fee labels on the UI

### Input Validation

Before submitting, the app checks:
- ✅ Student name must not be blank
- ✅ At least one course must be selected

---

## 🧠 Key Concepts Used

- WPF Project Structure (XAML + code-behind pair)
- XAML Layout Design with `StackPanel`, `Grid`, `Border`
- WPF Controls: `TextBox`, `CheckBox`, `RadioButton`, `TextBlock`, `Button`
- Event Handling — `Checked`, `Unchecked`, `Click`, `Loaded`
- Conditional Logic with `if-else` and `IsChecked`
- Input Validation with `string.IsNullOrWhiteSpace()`
- Number Formatting using `ToString("N0")`
- `isLoaded` guard variable to prevent premature event firing
- `MessageBox` dialogs for user feedback

---

## 👤 Author

**Hashim Ali**
Registration No. 247259

---

## 📄 License

This project is developed for **educational purposes** as part of the Visual Programming (Lab) course.
