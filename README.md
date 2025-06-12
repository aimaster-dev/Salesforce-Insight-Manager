# Salesforce Insight Manager

**Salesforce Insight Manager** is a Windows Forms desktop application built with .NET Framework 4.8 (C# 7.3) that provides advanced reporting, dashboard auditing, and user activity analysis for Salesforce environments. It is designed for business users, administrators, and analysts who need deeper insight and control over Salesforce data usage, access, and security.

---

## 🧩 Features

### 🔍 **Business Reporting**

* **Inactive Employees Reports**

  * Retired or withdrawn users
  * Inactive but not retired/withdrawn
* **User Activity Tracking**

  * Inactive users (no login for 180+ days)
  * Active users not running reports (180+ days)
* **Public Reports Not Used (90+ days)**

### 📊 **Dashboard Usage**

* Public and private dashboards usage
* Detect unused or underutilized dashboards
* Component-level dashboard insights

### 🔐 **Folder Security**

* Track who has access to what Salesforce folders
* Audit sharing and permission structures

### 📤 **Export and Custom Filtering**

* Export reports directly to Excel
* Upload Excel ignore lists to exclude records from analysis

---

## 🔗 Data Sources & APIs

| Source              | Purpose                                                        |
| ------------------- | -------------------------------------------------------------- |
| Salesforce SOAP API | Primary data access layer for reports, dashboards, users, etc. |
| Salesforce REST API | Optional support for OAuth2; not main data source              |
| Excel (Local Files) | For custom filtering via ignore lists                          |

* All credentials and endpoints are configured via `App.config`.
* Uses `SforceService` for SOAP API access.
* Optionally supports OAuth2 with `sfdcConsumerKey`, `sfdcConsumerSecret`.

---

## 💡 Why Use This App?

| Benefit                | Description                                                 |
| ---------------------- | ----------------------------------------------------------- |
| **Deeper Insights**    | Analyze usage patterns beyond standard Salesforce UI        |
| **Custom Filtering**   | Upload ignore lists for tailored queries                    |
| **Audit & Governance** | Monitor report/dashboard access and security for compliance |
| **Ease of Use**        | Familiar Windows UI makes navigation and management easy    |
| **Export Flexibility** | All results can be exported to Excel                        |

---

## 🧱 Architecture Overview

* **Frontend**: WinForms (.NET Framework 4.8)
* **Backend**: C# business logic using Salesforce SOAP API
* **Excel Parsing**: LinqToExcel for ignore list uploads
* **UI Assets**: Managed through embedded image resources

---

## 📁 Project Structure

```
SalesforceWindowsForms/
├── App.config                  # API keys, credentials, endpoints
├── SalesforceConnect.cs       # Handles API connection and session
├── Reports/
│   ├── InactiveUsersReport.cs
│   ├── DashboardUsageReport.cs
├── Utils/
│   ├── ExcelIgnoreListLoader.cs
│   ├── ExportToExcel.cs
├── Forms/
│   ├── MainForm.cs
│   ├── LoginForm.cs
```

---

## 🛠️ Setup & Usage

1. **Clone the repo**

   ```bash
   git clone https://github.com/aimaster-dev/salesforce-insight-manager.git
   ```
2. **Open in Visual Studio** (2019 or later recommended)
3. **Set up App.config** with your Salesforce credentials:

   ```xml
   <appSettings>
     <add key="UserName" value="your_salesforce_username"/>
     <add key="Password" value="your_password_with_security_token"/>
     <add key="ServerURLsoap" value="https://login.salesforce.com/services/Soap/u/54.0"/>
   </appSettings>
   ```
4. **Run the application** (Ctrl + F5)

---

## 🔒 Security Notes

* Do **not** hardcode credentials in code.
* Make sure `App.config` is excluded from version control if storing sensitive data.
* OAuth2 support available but not enabled by default.

---

## 🙋 Who Should Use This App?

This app is ideal for:

* Salesforce Admins
* Business Analysts
* IT Security Auditors
* Operations Managers needing user or asset visibility in Salesforce

---

## 📌 To Do / Planned Improvements

* Full integration with Salesforce REST API via OAuth2
* Automated scheduling/reporting
* Role-based access controls for app features
* Real-time report run status monitoring

---

## 📄 License

This project is under the [MIT License](LICENSE).

---
