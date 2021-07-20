# C++ - 고스톱 게임 콘솔 프로그램
[코드 전문](https://github.com/BlancBunny/BlancBunnyPortPolio/tree/main/Cpp%20-%20FlowerCardGame)    

## 1. 실행 결과 화면

#### 초기 화면
![image](https://user-images.githubusercontent.com/77951828/126114176-db0ec9c7-3578-4096-b9ce-6b0666aa35e4.png)

#### 게임 진행중
![image](https://user-images.githubusercontent.com/77951828/126243296-9441b54b-1bdf-4e77-87eb-2077c2d567aa.png)

----------------------

## 2. 클래스 구성
* CCardSet : 카드 동작 클래스 (카드 목록 삽입, 제거, 같은 숫자 찾기 등)   
  - CDeck (CCardSet 상속) : 카드덱 클래스 (셔플, 드로우 메소드)    

  - CPlayer (CCardSet 상속) : 게임 플레이어 클래스 (가진 손패 표시, 턴 관리)   
    + CBlanket (CPlayer 상속) : 게임판 클래스 (낸 카드와 깔려진 카드 일치 조사)    
    + CPlayerHand (CPlayer 상속) : 손패 클래스 (획득한 패 관리, 점수 계산)   

---------------------

## 3. 주요 코드 

#### 게임 구성 요소 
<pre><code>
// 카드 목록 (1~12월 피, 오, 십, 광, 쌍) 
SCard flowerCard[MaxCard] = {
	"1광", "1오", "1피", "1피", "2십", "2오", "2피", "2피", "3광", "3오", "3피", "3피",
	"4십", "4오", "4피", "4피", "5십", "5오", "5피", "5피", "6십", "6오", "6피", "6피",
	"7십", "7오", "7피", "7피", "8광", "8십", "8피", "8피", "9십", "9오", "9피", "9피",
	"J십", "J오", "J피", "J피", "D광", "D쌍", "D피", "D피", "B광", "B십", "B오", "B쌍",
};

// 카드명으로부터 카드 속성 추출
int GetNumber() const {
  if (isdigit(Name[0])) return Name[0] - '0';
  if (Name[0] == 'J') return 10; // 10월
  if (Name[0] == 'D') return 11; // 11월
  return 12;					   // 12월 
}
int GetKind() const {
  if (strcmp(Name + 1, "광") == 0) return 0;
  else if (strcmp(Name + 1, "십") == 0) return 1;
  else if (strcmp(Name + 1, "오") == 0) return 2;
  else if (strcmp(Name + 1, "쌍") == 0) return 3;
  else return 4; // 피
}

// 카드 정렬을 위한 비교연산자 오버로딩
bool operator <(const SCard& other) const {
  if (GetNumber() < other.GetNumber()) return true;
  if (GetNumber() > other.GetNumber()) return false;
  if (GetKind() > other.GetKind()) return true;
  return false;
}
</code></pre>


#### 카드를 목록에 삽입/제거

<pre><code>
void InsertCard(SCard c) {
  int i;
  if (c.Name[0] == 0) return;
  for (i = 0; i < num; i++) if (c < card[i]) break; // 카드를 비교하면서 올바른 위치에 삽입 (삽입 정렬 활용)
  memmove(&card[i + 1], &card[i], sizeof(SCard) * (num - i));
  card[i] = c;
  num++;
}

SCard RemoveCard(int idx) {
  assert(idx < num);
  SCard c = card[idx];
  memmove(&card[idx], &card[idx + 1], sizeof(SCard) * (num - idx - 1));
  num--;
  return c;
}
</code></pre>

#### 내고싶은 패 선택 시 숫자 입력 (1~10, 10은 a 입력)
<pre><code>
int InputInt(const char* message, int start, int end) {
  int ch;
  OutPrompt(message);
  for (;;) {
    ch = tolower(_getch());
    if (ch == 0xE0 || ch == 0) {
      ch = _getch();
      continue;
    }
    if (!(isdigit(ch) || ch == 'a')) continue;
    if (ch == 'a') ch = 10; else ch = ch - '0';
    if (ch >= start && ch <= end) {
      return ch;
    }

    OutPrompt("무효한 번호입니다. 지정한 범위에 맞게 다시 입력하세요.");
  }
}
</code></pre>

#### 게임 진행 
// 플레이어가 번갈아 가며 카드덱이 떨어질 때까지 게임 진행 
<pre><code>
for (southTurn = true; !deck.isEmpty(); southTurn = !southTurn) {
  DrawScreen();
  if (southTurn) {
   turn = &south;
   turnHand = &southHand;
   otherHand = &northHand;
  }
  else {
    turn = &north;
    turnHand = &northHand;
    otherHand = &southHand;
  }
  sprintf_s(mes, "내고 싶은 패를 선택하세요(1~%d, 0:종료) ", turn->GetNum());
</code></pre>


<pre><code>
// 1. 플레이어가 낸 카드와 게임판에 있는 카드 매치
userCard = turn->GetCard(userIdx);
sameNum = blanket.FindSameCard(userCard, arSame); // 같은 카드가 있는지 검색
switch (sameNum) {
  // 같은 카드 탐색 및 2개 이상 선택지가 있을 때 조사 
}

// 2. 덱에서 카드를 한장 뽑아 게임판에 있는 카드와 매치
deck.Draw(true);
delay(Speed);
deckCard = deck.Pop();
sameNum = blanket.FindSameCard(deckCard, arSame);

// 3. 매치된 카드 전부 자신의 점수판으로 회수
if (userSel != -1) {
			if (userTriple) {
				for (i = 0; i < 3; i++) {
					turnHand->InsertCard(blanket.RemoveCard(userSel - 1));
        }
			}
			else {
				turnHand->InsertCard(blanket.RemoveCard(userSel));
			}
			turnHand->InsertCard(turn->RemoveCard(userIdx));
		}
    turnHand->InsertCard(blanket.RemoveCard(deckSel));
		turnHand->InsertCard(deckCard);
		blanket.InsertCard(deckCard);
}
</code></pre>
