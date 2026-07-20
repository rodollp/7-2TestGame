# Docs/Refactoring/MonsterSpawnSystem.md

# Monster Spawn System 리팩토링 예정

## 1. MonsterFactory 도입

현재

```text
MonsterSpawner

↓

Instantiate
```

변경 예정

```text
MonsterSpawner

↓

MonsterFactory

↓

Instantiate
```

목적

- 생성 책임 분리
- Object Pool 적용 준비

---

## 2. Object Pool 적용

현재

```text
Instantiate

Destroy
```

변경 예정

```text
Pool.Get()

Pool.Release()
```

---

## 3. SpawnData 개선

현재

```text
MonsterPrefab[]
```

향후

```text
MonsterSpawnEntry[]

MonsterPrefab

Weight

SpawnCount
```

가중치를 이용한 랜덤 스폰 추가 예정

---

## 4. MonsterSpawner 개선

현재

플레이어 주변 랜덤 위치 생성

향후

- SpawnPoint 지원
- 맵 가장자리 스폰
- 특정 지역 스폰

추가 예정

---

## 5. Monster 이동

현재

NavMeshAgent

향후 검토

- FlyingMonsterMove
- JumpMonsterMove
- Boss 전용 이동