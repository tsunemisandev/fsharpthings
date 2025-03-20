module 銀行口座

open System

[<Measure>] type 円

type 金額 = 
    { 値: decimal<円> }
    
    static member inline (+) (a: 金額, b: 金額) = { 値 = a.値 + b.値 }
    static member inline (-) (a: 金額, b: 金額) = { 値 = a.値 - b.値 }
    static member inline (*) (a: 金額, factor: decimal) = { 値 = a.値 * factor }
    static member inline (/) (a: 金額, divisor: decimal) = { 値 = a.値 / divisor }

    static member inline op_LessThan  (a: 金額, b: 金額) = a.値 < b.値
    static member inline op_GreaterThan  (a: 金額, b: 金額) = a.値 > b.値
    static member inline op_LessThanOrEqual (a: 金額, b: 金額) = a.値 <= b.値
    static member inline op_GreaterThanOrEqual (a: 金額, b: 金額) = a.値 >= b.値
    static member inline op_Equality  (a: 金額, b: 金額) = a.値 = b.値
    static member inline op_Inequality (a: 金額, b: 金額) = a.値 <> b.値

let 円 (value: decimal) : 金額 = { 値 = value * 1M<円> }

/// 日時型
type 日時 = {値: DateTime}

/// 現在の日時を取得
let 現在の日時 () : 日時 = { 値 = System.DateTime.Now }

type 取引種別 = | 入金 | 出金

type 取引 = { 種別: 取引種別; 金額: 金額; 日時: 日時 }

type 口座 = { 残高: 金額; 取引履歴: 取引 list }

let 口座を作成 初期残高 = { 残高 = 初期残高; 取引履歴 = [] }

let 入金する 金額 口座 =
    let 取引 = { 種別 = 入金; 金額 = 金額; 日時 = 現在の日時() }
    { 口座 with 残高 = 口座.残高 + 金額; 取引履歴 = 取引 :: 口座.取引履歴 }

let 出金する 金額 口座 =
    if 金額 > 口座.残高 then 口座
    else
        let 取引 = { 種別 = 出金; 金額 = 金額; 日時 = 現在の日時() }
        { 口座 with 残高 = 口座.残高 - 金額; 取引履歴 = 取引 :: 口座.取引履歴 }

let 取引履歴を取得 口座 = List.rev 口座.取引履歴

let 取引履歴をフォーマット 口座 =
    口座
    |> 取引履歴を取得
    |> List.map (fun t ->
        let action = match t.種別 with | 入金 -> "入金" | 出金 -> "出金"
        sprintf "%s: %.2f円 (%s)" action t.金額.値 (t.日時.値.ToShortDateString()))

/// 過去30日間の取引を取得
let 過去30日間の取引 (口座: 口座) : 取引 list =
    let now = DateTime.Now
    let thirtyDaysAgo = now.AddDays(-30.0)
    口座.取引履歴
    |> List.filter (fun t -> t.日時.値 >= thirtyDaysAgo)  // Filter by date

/// 過去30日間の取引をフォーマット
let 過去30日間の取引をフォーマット (口座: 口座) : string list =
    口座
    |> 過去30日間の取引
    |> List.map (fun t ->
        let action = match t.種別 with | 入金 -> "入金" | 出金 -> "出金"
        sprintf "%s: %.2f円 (%s)" action t.金額.値 (t.日時.値.ToShortDateString()))