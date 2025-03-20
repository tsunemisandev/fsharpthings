module GinkoKoza

open System

// ================基本型================
[<Measure>] type Iene

/// 金額型（円の単位を持つ）
type Kingaku =
    { Value: decimal<Iene> }

/// `decimal` から `金額` を作成する関数
val Iene : value: decimal -> Kingaku

/// 日時型
type Nitiji = {Value: DateTime}

// ================固有型================

/// 取引の種類（入金 または 出金）
type TorihikiShubetu = 
    | Nyukin 
    | Shukin

/// 取引履歴（種類・金額・日時）
type Torihiki = {
    Shubetu: TorihikiShubetu
    Kingaku: Kingaku
    Nitiji: Nitiji
}

/// 銀行口座（残高 + 取引履歴）
type Koza = {
    Zandaka: Kingaku
    TorihikiRireki: Torihiki list
}

/// 新規口座を作成
val createKoza : 初期Zandaka: Kingaku -> Koza

/// 入金する
val doNyukin : Kingaku: Kingaku -> Koza: Koza -> Koza

/// 出金する（残高不足なら変更なし）
val doShukin : Kingaku: Kingaku -> Koza: Koza -> Koza

/// 取引履歴を取得
val fetchTorihikiRireki : Koza: Koza -> Torihiki list

/// 取引履歴をフォーマット
val formatTorihikiRireki : Koza: Koza -> string list

/// 過去30日間の取引履歴を取得
val formatPast30DayTorihikiRireki: Koza: Koza -> string list 