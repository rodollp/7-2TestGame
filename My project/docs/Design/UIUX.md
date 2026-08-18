## 화면 목록

### TitleScreen
- 시작 버튼
- 설정 버튼
- 종료 버튼

### PlayHUD
- 플레이어 체력바
- 플레이어 레벨
- 처치한 몬스터 수
- 플레이 시간
- 다음 웨이브/이벤트까지 남은 시간
- 현재 보유 골드
- 경험치 바
- 현재 무기 인벤토리

### LevelUpScreen
- 레벨업 선택지 3개
- 무기 이름 및 아이콘
- 현재 무기 레벨
- 획득 / 강화 효과 표시

### PauseScreen
- 계속하기 버튼
- 설정 버튼
- 타이틀로 돌아가기 버튼

### GameOverScreen
- 생존 시간
- 처치한 몬스터 수
- 도달 레벨
- 획득 골드
- 다시하기 버튼
- 타이틀로 돌아가기 버튼

### GameClearScreen
- 클리어 시간
- 처치한 몬스터 수
- 최종 레벨
- 획득 골드
- 다시하기 버튼
- 타이틀로 돌아가기 버튼

# Input Interface

## 플레이 중
- 이동 : WASD
- 점프 : Space
- 카메라 회전 : 마우스 이동
- 일시정지 : ESC

## 레벨업 화면
- 보상 선택 : 마우스 좌클릭
- 보상 선택 : 숫자키 1 / 2 / 3
- 레벨업 화면에서는 플레이어 이동 및 카메라 입력 비활성화

## 상자 오픈 화면 
- 상자를 열기 위해서 재화를 소모하는 상호작용키 입력
- 

## 일시정지 화면
- 계속하기 : ESC / 마우스 좌클릭 UI 버튼
- 설정 : 마우스 좌클릭 UI 버튼
- 타이틀로 돌아가기 : 마우스 좌클릭 UI 버튼

## 타이틀 화면
- 시작 : 마우스 좌클릭 UI 버튼
- 설정 : 마우스 좌클릭 UI 버튼
- 종료 : 마우스 좌클릭 UI 버튼

# UI Prefab 후보

- HealthBarUI
  - 플레이어의 현재 체력과 최대 체력을 표시
  - 체력 감소 시 게이지가 즉시 감소하도록 구성

- ExpBarUI
  - 현재 경험치와 다음 레벨업까지 필요한 경험치를 표시
  - 레벨 정보와 함께 배치

- WeaponSlotUI
  - 현재 보유 중인 무기 표시
  - 무기 아이콘
  - 무기 레벨
  - 최대 레벨 여부 표시

- LevelUpOptionUI
  - 레벨업 시 등장하는 보상 선택 UI
  - 무기 아이콘
  - 무기 이름
  - 현재 레벨
  - 획득 또는 강화 내용
  - 선택 버튼

- GoldUI
  - 현재 보유 중인 재화를 표시
  - 재화 아이콘과 숫자로 구성

- PlayTimeUI
  - 현재 플레이 시간을 표시
  - 분 : 초 형식으로 표현

- WaveTimeUI
  - 다음 웨이브 또는 이벤트까지 남은 시간을 표시

- KillCountUI
  - 현재까지 처치한 몬스터 수를 표시

- ResultItemUI
  - 게임 종료 후 결과 정보를 한 항목씩 표시할 때 사용
  - 생존 시간, 처치 수, 레벨, 재화 등의 결과 표시

  # Unity Object 초안

Canvas
└─ UI
   ├─ TitleScreen
   │  ├─ TitleText
   │  ├─ StartButton
   │  ├─ SettingButton
   │  └─ QuitButton
   │
   ├─ PlayHUD
   │  ├─ PlayerHUD
   │  │  ├─ HealthBarUI
   │  │  ├─ ExpBarUI
   │  │  └─ LevelText
   │  │
   │  ├─ BattleInfo
   │  │  ├─ PlayTimeUI
   │  │  ├─ WaveTimeUI
   │  │  └─ KillCountUI
   │  │
   │  ├─ CurrencyHUD
   │  │  └─ GoldUI
   │  │
   │  └─ WeaponInventoryUI
   │     ├─ WeaponSlotUI
   │     ├─ WeaponSlotUI
   │     └─ WeaponSlotUI
   │
   ├─ LevelUpScreen
   │  ├─ Background
   │  ├─ LevelUpTitle
   │  └─ RewardContainer
   │     ├─ LevelUpOptionUI
   │     ├─ LevelUpOptionUI
   │     └─ LevelUpOptionUI
   │
   ├─ PauseScreen
   │  ├─ ContinueButton
   │  ├─ SettingButton
   │  └─ TitleButton
   │
   ├─ GameOverScreen
   │  ├─ ResultTitle
   │  ├─ ResultContainer
   │  ├─ RetryButton
   │  └─ TitleButton
   │
   ├─ GameClearScreen
   │  ├─ ResultTitle
   │  ├─ ResultContainer
   │  ├─ RetryButton
   │  └─ TitleButton
   │
   └─ SettingScreen
      ├─ SoundSetting
      ├─ MouseSensitivity
      └─ BackButton

# 리소스 및 콘셉트 결정

## 글꼴
- 한글 지원 폰트 사용
- 전투 중 빠르게 읽을 수 있도록 가독성을 우선
- 숫자 정보는 크고 명확하게 표현
- 제목과 일반 UI 텍스트의 크기 차이를 명확하게 구분

## 전체 UI 콘셉트
- 3D 전투 화면을 가리지 않는 간결한 HUD 구성
- 전투 중 필요한 정보만 항상 표시
- 체력, 경험치, 플레이 시간 등 중요 정보는 화면 가장자리 배치
- 화면 중앙은 플레이어와 몬스터를 확인할 수 있도록 최대한 비움

## 체력 UI
- 체력이 감소하면 게이지가 줄어드는 방식
- 체력이 낮아질수록 위험 상태임을 쉽게 인식할 수 있도록 강조
- 숫자 또는 현재 HP / 최대 HP 병행 표시 고려

## 경험치 UI
- 화면 하단 또는 상단에 긴 게이지 형태로 배치
- 경험치 획득 시 게이지 증가
- 레벨업 시 게이지 초기화 후 다음 레벨 기준으로 갱신
- 현재 레벨을 경험치 바 근처에 표시

## 무기 UI
- 무기마다 아이콘 사용
- 현재 보유 중인 무기를 슬롯 형태로 표시
- 무기 레벨을 아이콘 근처 숫자로 표시
- 최대 레벨 도달 시 별도 표시 또는 강조 효과 적용

## 레벨업 UI
- 레벨업 발생 시 게임 일시 정지
- 화면 배경을 어둡게 처리하여 선택지에 집중하도록 구성
- 선택지 3개를 동일한 크기로 나란히 배치
- 현재 보유 무기 강화인지 새로운 무기 획득인지 쉽게 구분
- 마우스를 올린 선택지는 크기 증가 또는 테두리 강조

## 재화 UI
- 골드 또는 재화 아이콘 + 현재 수량으로 표현
- 획득 시 숫자가 즉시 증가
- 필요하다면 짧은 증가 애니메이션 적용

## 플레이 시간 / 웨이브 시간
- 플레이 시간과 다음 이벤트 시간을 서로 구분해서 표시
- 플레이 시간은 게임 진행 시간을 확인하는 용도
- 웨이브 시간은 다음 변화 시점을 예측할 수 있도록 표시

## 처치 수
- 몬스터 아이콘 또는 간단한 텍스트와 함께 숫자로 표시
- 전투 중 계속 갱신
- 결과 화면의 최종 처치 수와 동일한 데이터를 사용

## 버튼
- 기본 상태 / Hover / Pressed / Disabled 상태를 구분
- Hover 시 밝기 또는 크기를 변화
- 클릭 시 짧게 눌리는 피드백 적용
- 설정 버튼에는 톱니바퀴 등 의미를 바로 이해할 수 있는 아이콘 사용

## 레벨업 선택 피드백
- 선택 가능한 보상에 마우스를 올리면 테두리 또는 배경 강조
- 선택 시 해당 UI를 순간적으로 강조한 뒤 레벨업 화면 종료
- 선택 완료 후 PlayHUD로 복귀

## 게임 오버 / 클리어
- 게임 플레이 화면과 명확하게 구분
- 최종 생존 시간, 처치 수, 레벨, 획득 재화를 우선적으로 표시
- GameOver와 GameClear는 동일한 레이아웃을 공유하되 제목과 연출을 다르게 구성

