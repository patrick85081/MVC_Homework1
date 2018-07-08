﻿# MVC Homework 1

## 作業要求
* [x] [資料庫下載連結](https://drive.google.com/open?id=0B9TSNtgzYzPTSGR5TEc4TjcwZmM) or [資料庫SQL下載連結](https://drive.google.com/open?id=1AX0x00BUM3N47mY8fLoaL47QPI_ERbKl)
* [x] 請使用 "客戶資料" 這個資料庫做開發 (如附件檔案)
* [ ] 請實作出「客戶資料管理」、「客戶聯絡人管理」與「客戶銀行帳戶管理」等簡易 CRUD 功能 (盡量做各種功能出來)
* [ ] 在列表頁要實作「搜尋」功能
* [x] 實作一個清單頁面，顯示欄位有「客戶名稱、聯絡人數量、銀行帳戶數量」共三個欄位，此功能要在資料庫中建立一個檢視表，並且匯入 EDMX。
* [ ] 主選單要有連結可以**直接連到三個主要功能**的列表頁。
* [x] 對於 **Create** 與 **Edit** 表單要套用欄位驗證 (必填、Email格式、欄位長度限制等驗證)
* [ ] 刪除資料功能不能真的刪除資料庫中的資料，必須修改資料庫，加上一個「是否已刪除」欄位，資料庫中的該欄位為 bit 類型，`0 代表未刪除，1 代表已刪除`，且列表頁不得顯示已刪除的資料。
* [ ] 實作「客戶聯絡人」時，同一個客戶下的聯絡人，其 Email 不能重複。
* [ ] 實作一個「自訂輸入驗證屬性」可驗證「手機」的電話格式必須為 `"\d{4}-\d{6}"` 的格式 ( e.g. 0911-111111 )
* [ ] 使用 **Repository Pattern** 管理所有新刪查改(CRUD)等功能
* [ ] 修改所有的「刪除」邏輯，**所有資料都不能真正被刪除**，資料庫中也要新增「是否已刪除」欄位 (欄位要設定 bit 型態)
* [ ] 修改「客戶資料」表格，新增「客戶分類」欄位，可設定特定選項的分類
* [ ] 在「客戶資料列表」頁面新增篩選功能，可以用「客戶分類」欄位進行資料篩選 **(下拉選單)**
* [ ] 資料篩選的邏輯要寫在 **Repository** 的類別裡面
* [ ] 在「客戶聯絡人列表」頁面新增篩選功能，可以用「職稱」欄位進行資料篩選
* [ ] 修改「客戶資料列表」與「客戶聯絡人列表」頁面，設定讓每個欄位都能進行排序 (可升冪、可降冪排序)
* [ ] 如果可以的話，透過 `JavaScript` 實作一些 `AJAX` 操作，後端 MVC 使用 `JsonResult` 進行回應
* [ ] 使用 `ClosedXML` 這個 NuGet 套件實作資料匯出功能，每個清單頁上都要有可以匯出 Excel 檔案的功能，要用到 FileResult 下載檔案