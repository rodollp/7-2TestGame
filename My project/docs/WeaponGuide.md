# 자동 공격 시스템 구조

## 전체 구조

```text
┌──────────────────────────┐
│      WeaponInventory     │
│──────────────────────────│
│ 보유한 WeaponStatus 목록  │
│ 무기 추가 / 레벨업         │
│ 무기 제거                 │
└────────────┬─────────────┘
             │ Weapons
             ▼
┌──────────────────────────┐
│ PlayerWeaponController   │
│──────────────────────────│
│ 모든 무기 순회            │
│ 무기별 쿨타임 관리        │
│ TargetFinder 호출        │
│ AttackStrategy 실행      │
└───────┬──────────┬───────┘
        │          │
        │          │ Weapon Range
        │          ▼
        │  ┌──────────────────────┐
        │  │     TargetFinder     │
        │  │──────────────────────│
        │  │ 살아있는 적 검색      │
        │  │ Range 체크           │
        │  │ 가장 가까운 적 반환   │
        │  └──────────┬───────────┘
        │             │
        ▼             ▼
┌──────────────────────────┐
│     AttackStrategy       │
│──────────────────────────│
│ SwordAttack              │
│ HammerAttack             │
│ ProjectileAttack         │
│ AreaAttack               │
└────────────┬─────────────┘
             │
             ▼
┌──────────────────────────┐
│      PlayerAttack        │
│──────────────────────────│
│ 최종 데미지 계산         │
│ Player + Weapon          │
│ target.TakeDamage()      │
└──────────────────────────┘
```

---

# 데이터 구조

```text
┌──────────────────────────┐
│        WeaponData        │
│──────────────────────────│
│ WeaponName               │
│ WeaponType               │
│ WeaponLevelData[]        │
│ AttackStrategy           │
└────────────┬─────────────┘
             │
             ▼
┌──────────────────────────┐
│      WeaponStatus        │
│──────────────────────────│
│ WeaponData 참조          │
│ CurrentLevel             │
│ CurrentData              │
│ IsMaxLevel               │
└──────────────────────────┘
```

---

# 공격 처리 흐름

```text
Update()
    │
    ▼
WeaponInventory.Weapons 순회
    │
    ▼
무기별 타이머 증가
    │
    ▼
쿨타임 확인
    │
    ├── NO → 다음 무기
    │
    └── YES
          │
          ▼
TargetFinder.FindNearestTarget()
          │
          ├── 타겟 없음
          │      │
          │      └── 대기 (타이머 유지)
          │
          └── 타겟 있음
                 │
                 ▼
AttackStrategy.Attack()
                 │
                 ▼
PlayerAttack.Damage()
                 │
                 ▼
target.TakeDamage()
                 │
                 ▼
타이머 초기화
```

---

# 클래스 역할

## WeaponInventory

### 담당

- 무기 보관
- 무기 추가
- 무기 제거
- 무기 레벨업

### 담당하지 않음

- 공격
- 쿨타임
- 타겟 탐색

---

## PlayerWeaponController

### 담당

- 모든 무기 순회
- 무기별 쿨타임
- TargetFinder 호출
- AttackStrategy 실행

### 담당하지 않음

- 데미지 계산
- 몬스터 검색
- 무기 공격 구현

---

## TargetFinder

### 담당

- 살아있는 적 찾기
- Range 검사
- 가장 가까운 적 반환

### 담당하지 않음

- 공격
- 데미지 계산
- 쿨타임

---

## AttackStrategy

### 담당

- 무기 고유 공격

예시

- SwordAttack
- HammerAttack
- ProjectileAttack
- AreaAttack

### 담당하지 않음

- 타겟 검색
- 쿨타임
- 인벤토리

---

## PlayerAttack

### 담당

- 최종 데미지 계산
- Player 공격력 + Weapon 공격력
- TakeDamage 호출

### 담당하지 않음

- 무기 관리
- 타겟 탐색
- 쿨타임

---

# 구현 순서

```text
[완료]
✔ WeaponInventory
✔ WeaponStatus
✔ PlayerAttack
✔ TargetFinder

        │
        ▼

[진행]
□ PlayerWeaponController

        │
        ▼

[다음]
□ WeaponData ↔ AttackStrategy 연결

        │
        ▼

□ SwordAttack 구현

        │
        ▼

□ 기존 AutoAttack 제거

        │
        ▼

□ 투사체
□ 범위공격
□ 이펙트
□ 오브젝트 풀링
```

---

# 최종 목표

```text
Player
│
├── PlayerStatus
├── PlayerAttack
├── WeaponInventory
├── PlayerWeaponController
└── TargetFinder
                │
                ▼
         AttackStrategy
                │
                ▼
          PlayerAttack
                │
                ▼
          MonsterStatus
```

**핵심 원칙**

- PlayerWeaponController → 공격 흐름을 관리한다.
- TargetFinder → 누구를 공격할지 결정한다.
- AttackStrategy → 어떻게 공격할지 결정한다.
- PlayerAttack → 얼마나 데미지를 줄지 계산한다.
- WeaponData → 무기의 설정값만 가진다.
- WeaponStatus → 게임 중 변경되는 무기 상태를 가진다.