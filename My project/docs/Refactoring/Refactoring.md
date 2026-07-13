# Docs/Refactoring/CombatRefactoring.md

# Combat 리팩터링 계획

현재 공격 구조는 큰 틀에서는 안정적으로 구성되었다.

이후에는 새로운 구조를 추가하기보다 현재 구조를 다듬는 방향으로 진행한다.

---

# 우선순위

## 1순위 - Projectile 안정화

### 수정 사항

- Rigidbody 체크 수정
- Init() 초기화 보완
- Timer 초기화
- Rigidbody Velocity 초기화
- 비활성화 시 상태 초기화

목표는 Object Pool 적용이 가능한 Projectile 구조를 만드는 것이다.

---

## 2순위 - PlayerWeaponController

현재 구조

PlayerWeaponController

↓

TargetFinder

↓

AttackStrategy

↓

ProjectileSpawner

↓

Projectile

↓

PlayerAttack

↓

IDamageable

현재 구조를 그대로 유지하면서

- 무기 순회
- 쿨다운 관리
- 공격 실행

만 담당하도록 책임을 유지한다.

---

## 3순위 - 검, 활 동시 검증

동시에 여러 무기를 장착했을 때

- 각각 다른 쿨다운
- 각각 다른 공격 방식

이 정상적으로 동작하는지 확인한다.

---

## 4순위 - AreaAttack 구현

세 번째 공격 방식을 추가하여

- 근접 공격
- 투사체 공격
- 범위 공격

세 가지가 같은 구조에서 동작하는지 검증한다.

---

## 5순위 - MonsterFactory 제작

몬스터 생성 책임을 담당하는 Factory를 만든다.

Factory 역할

- 생성
- 초기화

Factory가

- 이동
- 공격
- 드랍

을 담당하지 않도록 한다.

---

## 6순위 - Object Pool 적용

추천 순서

1. Projectile Pool
2. Monster Pool
3. ExpOrb Pool
4. Effect Pool

ProjectileSpawner 내부만 수정하여 Pool을 적용할 수 있도록 유지한다.

---

## 7순위 - MonsterRegistry 구현

현재

```csharp
FindObjectsByType<MonsterStatus>()
```

를 사용하고 있다.

MonsterFactory와 Object Pool이 완성되면

MonsterRegistry를 추가하여 활성화된 몬스터를 관리한다.

TargetFinder는 Registry만 조회하도록 변경한다.

---

# 현재 리팩터링하지 않는 부분

다음 기능은 실제 필요성이 생길 때 추가한다.

- Projectile 상속 구조
- 상태 이상 시스템
- 관통 시스템
- 유도탄
- 부메랑
- 무기 융합
- 범용 EventManager
- Service Locator

현재는 구조보다 전투 루프를 완성하는 것이 우선이다.

---

# 추천 개발 순서

1. Projectile 안정화
2. PlayerWeaponController 완성
3. 검 + 활 검증
4. AreaAttack 구현
5. MonsterFactory 제작
6. Projectile Object Pool
7. Monster Object Pool
8. MonsterRegistry 구현
9. TargetFinder 개선
10. 이후 확장 시스템 구현