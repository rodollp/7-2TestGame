# Docs/Design/MonsterSpawnSystem.md

# Monster Spawn System

## 목적

시간에 따라 다른 몬스터를 생성하는 시스템

---

## 전체 구조

```text
StageData
│
└── SpawnData[]
        │
        ▼
MonsterSpawnManager
        │
        ▼
MonsterSpawner
        │
        ▼
Monster Prefab
```

---

## StageData

스테이지 전체의 스폰 데이터를 관리한다.

```text
StageData

SpawnData[]

StageDuration
```

---

## SpawnData

특정 시간 구간의 스폰 규칙

```text
SpawnData

StartTime

EndTime

SpawnInterval

SpawnCount

MonsterPrefabs
```

---

## MonsterSpawnManager

책임

- 현재 게임 시간 계산
- 현재 SpawnData 검색
- SpawnInterval 계산
- MonsterSpawner 호출

즉,

> 언제 소환할 것인가를 담당한다.

---

## MonsterSpawner

책임

- 생성 위치 계산
- 생성할 몬스터 선택
- Instantiate

즉,

> 어떻게 소환할 것인가를 담당한다.

---

## 동작 순서

```text
게임 시작

↓

게임 시간 증가

↓

현재 SpawnData 검색

↓

SpawnInterval 확인

↓

MonsterSpawner 호출

↓

플레이어 주변 위치 계산

↓

Instantiate
```