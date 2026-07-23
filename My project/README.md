# Project Rogue

> Unity 6 기반 3D Action Roguelite Prototype

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

Project Rogue는 Unity 6를 사용하여 제작 중인 3D 액션 로그라이트 프로젝트입니다.

플레이어는 제한 시간 동안 몬스터를 처치하며 경험치를 획득하고,
레벨업을 통해 무기와 능력치를 성장시킬 수 있습니다.

현재는 전투 루프와 성장 시스템을 중심으로 구현하고 있으며,
기능을 확장하기 쉬운 구조를 만드는 것을 목표로 개발하고 있습니다.

---

# 현재 구현 기능

### 플레이어

- 이동
- 카메라 회전
- 체력 시스템
- 경험치 및 레벨업
- 골드 획득

### 전투

- 자동 공격
- 근접 무기
- 원거리 무기(Projectile)
- 무기 레벨업

### 몬스터

- NavMesh 기반 추적
- 플레이어 공격
- 경험치 / 골드 드롭

### 성장

- 랜덤 레벨업 보상
- 능력치 강화
- 무기 획득 및 강화

### 게임 진행

- 타이틀 화면
- 게임 시작
- 게임 오버
- 게임 클리어
- 생존 시간 기반 스테이지 진행

---

# 프로젝트 구조

## Player

- PlayerStatus
- PlayerAttack
- PlayerWeaponController
- WeaponInventory

## Monster

- MonsterStatus
- MonsterMove
- MonsterDamage
- MonsterDrop

## System

- GameManager
- GameStateManager
- GameTimer
- MonsterManager
- MonsterSpawnSystem
- MonsterSpawner
- LevelUpManager

## Data

- PlayerData
- MonsterData
- WeaponData
- WeaponLevelData

---

# 사용 기술

### Unity

- Unity 6
- Input System
- NavMesh
- Physics
- UI (TextMeshPro)

# 구현하면서 중점적으로 고민한 부분

- ScriptableObject를 활용한 데이터 관리
- 무기 공격 방식의 Strategy Pattern 적용 (전략 패턴)
- 이벤트 기반 시스템 구성
- 기능별 Manager 분리
- 컴포넌트 중심 구조 설계
- 유지보수를 고려한 클래스 역할 분리

---

# 개발 예정

- Object Pooling
- 엘리트 몬스터
- 보스 몬스터
- 사운드
- VFX
- 저장 / 불러오기

---

# 개발 진행 현황

## Core

- [x] 플레이어 이동
- [x] 자동 전투
- [x] 무기 시스템
- [x] 레벨업
- [x] 몬스터 스폰
- [x] 게임 진행

## UI

- [x] 타이틀 화면
- [x] HUD
- [x] 레벨업 UI
- [x] 게임 오버
- [x] 게임 클리어

## ETC

- [ ] Object Pooling
- [ ] 사운드
- [ ] VFX
- [ ] 보스