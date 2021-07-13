# C언어 연결 리스트 기반 삽입 정렬 구현 코드
[코드 전문](https://github.com/BlancBunny/BlancBunnyPortPolio/blob/main/CProc%20-%20Linked_List%2BSelection_Sort/StudyC/StudyC/insertionSort_linkedList.c)

## 구현 목표
대소문자 구분없이 입력된 문자열을 삽입정렬을 사용하여 정렬하고 대소문자 분리   
리스트에 노드가 없을 경우 빈리스트 오류를 출력하고    
노드가 1개일 경우 정렬하지 않고 바로 return    

<pre><code>
  ex) rAtxPGr   
  A -> G -> P
  r -> r -> t -> x
  
  ex) A
  => 단일 노드 리스트
  
</code></pre>
## 실행 결과 캡쳐    
![image](https://user-images.githubusercontent.com/77951828/125396572-adeef000-e3e7-11eb-85e2-ec547cf305ab.png)
![image](https://user-images.githubusercontent.com/77951828/125396837-0faf5a00-e3e8-11eb-8daf-bf9104556782.png)


-------------------

## 주요 함수   

#### 삽입정렬 함수 : 리스트에 새로운 노드를 정렬하면서 삽입
<pre><code>
  void sortedInsert(HeadNode* h, ListNode* newNode) {
  	ListNode* curr; 
  	// 헤드 포인터에 삽입될 때
  	if (h->head == NULL || h->head->data >= newNode->data) {
  		newNode->link = h->head;
  		h->head = newNode;
  		return;
  	}
  	curr = h->head;
  	while (curr->link != NULL && curr->link->data < newNode->data) {
  		curr = curr->link;
  	}
  	newNode->link = curr->link;
  	curr->link = newNode;
  }
</code></pre>



#### 리스트 삽입 정렬 : 비정렬 리스트를 sorted 리스트에 정렬하면서 삽입
##### 완성된 sorted 리스트를 h에 저장
<pre><code>
void insertionSort(HeadNode* h) {
	HeadNode* sorted = createLinkedList();
	ListNode* curr = h->head;
	while (curr != NULL) {
		ListNode* tmp = curr->link;
		sortedInsert(sorted, curr);
		curr = tmp;
	}
	h->head = sorted->head;
}
</code></pre>
