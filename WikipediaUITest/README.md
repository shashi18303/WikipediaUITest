
# Wikipedia UI Test Automation

This project is an **automated UI test** built with **.NET 9**, **Selenium WebDriver**, and **NUnit**.  
It navigates to the Wikipedia page for **"Test automation"**, extracts the **Test-Driven Development (TDD)** section text, counts the frequency of unique words, and prints the results.

---

## 📌 Features
- **UI Automation** using **Selenium WebDriver** (ChromeDriver).
- **Extract and Analyze Text** from the TDD section of the Wikipedia page.
- **Word Frequency Calculation** with custom text processing logic.
- **NUnit Test Framework** for structured test execution.
- **Cross-browser ready** (easily extendable).
- Clean code with `SetUp` and `TearDown` for WebDriver management.

---

## 📂 Project Structure
```
WikipediaUITest/
│
├── Drivers/              # Contains WebDriverFactory for browser creation
├── Pages/                # WikipediaPage.cs (Page Object for Wikipedia)
├── Services/             # TextProcessor.cs (Text parsing & word counting)
├── Tests/                # WikipediaTests.cs (NUnit tests)
└── WikipediaUITest.csproj
```

---

## ⚙️ Prerequisites
1. **.NET SDK 9.0 or later**  
   [Download here](https://dotnet.microsoft.com/download)
2. **Google Chrome** (latest version)
3. **ChromeDriver** (automatically handled by Selenium Manager in new versions)
4. **NUnit Test Adapter & NUnit Console Runner** (installed via NuGet)

---

## 🛠️ Installation & Setup
```bash
# Clone the repository
git clone <your_repo_url>
cd WikipediaUITest

# Restore NuGet dependencies
dotnet restore
```

---

## ▶️ How to Build & Run Tests
```bash
# Clean the project
dotnet clean

# Build the project
dotnet build

# Run tests
dotnet test
```

---

## 📄 Example Output
When you run `dotnet test`, you will see:

```
=== TDD SECTION TEXT ===
<Test Driven Development text from Wikipedia...>

=== WORD COUNTS ===
the -> 98
of -> 54
test -> 49
...
```

---

## ⚠️ Notes
- If you see **NoSuchElementException**, it means the XPath selector in `WikipediaPage.cs` may need an update because Wikipedia changed its structure.
- NUnit warnings like `NUnit1033` are harmless but can be removed by replacing `Console.WriteLine` with `TestContext.WriteLine`.

---

## 🚀 Future Improvements
- **Async Test Methods** for better scalability (optional).
- **Parallel Test Execution** for speed improvements.
- **Cross-browser testing** (Firefox, Edge).
- **CI/CD Integration** (GitHub Actions or Azure Pipelines).

---

## 👨‍💻 Author
**Shashikumar Naik**  
(Automation Tester - Wikipedia UI Test Assignment)
