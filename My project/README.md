# Project Rogue

> Unity 6 기반 3D Action Roguelite

---

# 프로젝트 정보

| 항목 | 내용 |
|------|------|
| 장르 | 3D Action Roguelite |
| 엔진 | Unity 6 |
| 언어 | C# |
| 개발 인원 | 1인 |
| 플랫폼 | PC |

---

# 프로젝트 소개

Project Rogue는 Unity 6를 이용하여 제작하는
3D 액션 로그라이트 게임입니다.

플레이어는 다양한 캐릭터와 무기를 활용하여
스테이지를 돌파하고 성장하며,
최종 보스를 처치하는 것을 목표로 합니다.

매 플레이마다 능력 선택을 통해
다양한 플레이 스타일을 경험할 수 있도록 개발하고 있습니다.

---

# 핵심 콘텐츠

- 실시간 액션 전투
- 로그라이트 성장 시스템
- 다양한 캐릭터
- 다양한 무기
- 랜덤 능력 선택
- 엘리트 몬스터
- 보스전

---

# 게임 진행

```
Start

↓

Character Select

↓

Weapon Select

↓

Stage 1

↓

Level Up

↓

Ability Select

↓

Stage 2

↓

Elite Stage

↓

Stage 3

↓

Boss

↓

Game Clear
```

---

# 콘텐츠

## 캐릭터

- Warrior
- Archer
- Mage

---

## 무기

- Sword
- Bow
- Staff

---

## 스테이지

- Forest
- Cave
- Ruins

---

## 몬스터

- Slime
- Goblin
- Orc
- Skeleton
- Golem

---

## 보스

- Dragon

---

# 플레이어

### 이동

- 이동
- 점프
- 대시
- 회피

### 전투

- 일반 공격
- 스킬 공격

### 성장

- 경험치
- 레벨업
- 능력 선택
- 무기 강화

---

# 몬스터 AI

FSM 기반 AI

- Idle
- Chase
- Attack

엘리트 몬스터

보스 AI

---

# 아이템

- 회복 포션
- 능력 강화
- 무기 강화
- 유물

---

# UI

HUD

- HP
- EXP
- Level
- Gold
- Stage

---

# 시스템 구조

## Player

- PlayerInput
- PlayerMovement
- PlayerCombat
- PlayerStatus

---

## Monster

- MonsterAI
- MonsterCombat
- MonsterStatus

---

## Manager

- GameManager
- StageManager
- SpawnManager
- UIManager
- AudioManager

---

## Data

- CharacterData
- WeaponData
- MonsterData
- ItemData

---

## Item

- Inventory
- DropItem

---

# 사용 기술

## Player

- Input System
- Character Controller

## AI

- FSM
- NavMesh

## Battle

- Physics
- Raycast
- SphereCast
- KnockBack

## Data

- ScriptableObject
- List
- Dictionary
- Event(Action)

## Unity

- Animation
- Prefab
- UI
- Physics

---

# 구현 목표

- 컴포넌트 기반 구조 설계
- 역할별 클래스 분리
- FSM 기반 AI
- 이벤트 기반 시스템
- 데이터 중심 설계
- 유지보수가 쉬운 코드 구조
- 확장 가능한 콘텐츠 구조

---

# 개발 예정

- 랜덤 스테이지 생성
- 랜덤 능력 선택 시스템
- 유물 시스템
- 스킬 시스템
- 저장 / 불러오기
- 사운드
- VFX
- Object Pooling
- 옵션 메뉴

---

# 개발 진행 상황

## Core

- [ ] 플레이어 이동
- [ ] 전투
- [ ] 카메라
- [ ] 몬스터 AI

## Stage

- [ ] 스테이지 진행
- [ ] 보스 스테이지

## Growth

- [ ] 레벨업
- [ ] 능력 선택
- [ ] 아이템

## UI

- [ ] HUD
- [ ] 결과 화면

## ETC

- [ ] 사운드
- [ ] VFX
- [ ] 저장

