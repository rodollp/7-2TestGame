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

# 7-3
1. CreatureData 부모로 정리
2. PlayerData 만들기
3. PlayerData.asset 생성
4. PlayerStatus에서 데이터 복사
5. PlayerMove가 PlayerStatus.MoveSpeed 사용
6. 실행해서 MoveSpeed 값을 바꾸면 이동속도가 바뀌는지 확인
- 카메라 정면이 앞이 되게 설정했는데 위아래 회전 구현에 있어서 한계를 느끼고 CameraRoot(좌우)과 CameraPivot(상하)로 나눔
- 시네머신 활용으로 보고 있긴하지만 뭔가 석연치 않음 개선 필요
- 그로 인해서 PlayerMove 이동방식을 월드기준 >> 카메라 정면 기준으로 바꿈
- PlayerRotate도 동일

# 7-6

## 데이터 구조

### PlayerData
- Player의 기본 능력치를 ScriptableObject로 분리
- 최대 HP
- 공격력
- 이동속도
- 점프력

### MonsterData
- Monster의 기본 능력치를 ScriptableObject로 분리
- 이름
- 최대 HP
- 공격력
- 이동속도
- 경험치 보상
- 골드 보상

### WeaponData
- 무기의 데이터를 ScriptableObject로 분리
- 공격력
- 공격 쿨타임
- 공격 범위

---

## 전투 시스템

### PlayerAttack
- Player의 공격 처리 담당
- 무기 공격력 + 플레이어 공격력을 합산하여 최종 데미지 계산
- IDamageable 인터페이스를 통해 대상에게 데미지 적용

### AutoAttack
- 일정 시간마다 공격 쿨타임 계산
- 가장 가까운 몬스터 탐색
- 무기 사거리 내 몬스터인지 확인
- 조건 충족 시 자동 공격 실행

---

## 몬스터 탐색

- FindObjectsByType()을 이용하여 씬 내 모든 몬스터 탐색
- 살아있는 몬스터만 탐색 대상에 포함
- sqrMagnitude를 이용하여 가장 가까운 몬스터 선택
- 선택된 몬스터를 자동 공격 대상으로 지정

---

## 구조 개선

- AttackTest를 AutoAttack으로 변경
- 공격 조건을 CanAttack() 함수로 분리
- 사거리 확인을 IsInRange() 함수로 분리
- 공격 로직을 Attack() 함수로 분리하여 역할 분리

---

## 확인 사항

- 자동 공격 정상 동작 확인
- 가장 가까운 몬스터 우선 공격 확인
- WeaponData의 Range와 Cooldown이 정상적으로 적용되는 것 확인