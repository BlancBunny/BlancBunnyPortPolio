#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct listNode {
	char data;
	struct listNode* link;
}ListNode;

typedef struct {
	ListNode* head;
}HeadNode;

/// <summary>
/// 새로운 리스트 생성 
/// </summary>
/// <returns>빈 리스트 반환</returns>
HeadNode* createLinkedList() {
	HeadNode* h;
	h = (HeadNode*)malloc(sizeof(HeadNode));
	if (h != NULL) h->head = NULL;
	return h;
}

/// <summary>
/// 새로운 노드 생성
/// </summary>
/// <param name="ch">노드에 포함된 데이터 (영문자)</param>
/// <returns>노드 반환</returns>
ListNode* createNode(char ch) {
	ListNode* newNode = (ListNode*)malloc(sizeof(ListNode));
	if (newNode == NULL) {
		printf("memory alloc fail!\n");
		return NULL;
	}
	newNode->data = ch;
	newNode->link = NULL;

	return newNode;
}

/// <summary>
/// 리스트 제일 끝에 노드 삽입
/// </summary>
/// <param name="h">리스트 헤드</param>
/// <param name="newNode">삽입할 노드</param>
void insertLastNode(HeadNode* h, ListNode* newNode) {
	ListNode* tmp = h->head;
	if (h->head == NULL) {
		h->head = newNode;
		return;
	}
	while (tmp->link != NULL) {
		tmp = tmp->link;
	}
	tmp->link = newNode;
}

/// <summary>
/// 리스트 출력 함수
/// </summary>
/// <param name="h">출력할 리스트</param>
void printList(HeadNode* h) {
	if (h->head == NULL) {
		printf("List : ()\n");
		return;
	}
	ListNode* tmp = h->head;
	printf("List : (");
	while (tmp != NULL) {
		printf("%c", tmp->data);
		if (tmp->link != NULL) printf(" -> ");
		tmp = tmp->link;
	}
	printf(")\n");
}


/// <summary>
/// 배열 -> 리스트 변환 함수
/// </summary>
/// <param name="ary">변환할 배열</param>
/// <returns>변환된 리스트</returns>
HeadNode* aryToList(char* ary) {
	HeadNode* h = createLinkedList();
	for (int i = 0; ary[i] != 0; i++) {
		insertLastNode(h, createNode(ary[i]));
	}
	return h;
}


/// <summary>
/// 삽입정렬 함수 : 리스트에 새로운 노드를 정렬하면서 삽입
/// </summary>
/// <param name="h">정렬 리스트</param>
/// <param name="newNode">삽입할 노드</param>
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

/// <summary>
/// 리스트 삽입 정렬 :
/// 비정렬 리스트를 sorted 리스트에 정렬하면서 삽입
/// 완성된 sorted 리스트를 h에 저장
/// </summary>
/// <param name="h">비정렬 리스트</param>
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


/// <summary>
/// 정렬된 리스트를 대문자와 소문자로 분류하는 함수
/// </summary>
/// <param name="h">정렬된 리스트</param>
/// <param name="h_upper">대문자 리스트</param>
/// <param name="h_lower">소문자 리스트</param>
void makeList(HeadNode* h, HeadNode* h_upper, HeadNode* h_lower) {
	ListNode* tmp = h->head;
	ListNode* node;
	h_upper->head = h->head;
	while (tmp->link != NULL) {
		// 대, 소문자 경계 노드 탐색
		if (tmp->data >= 'A' && tmp->data <= 'Z' && tmp->link->data >= 'a' && tmp->link->data <= 'z') { 
			h_lower->head = tmp->link;
			tmp->link = NULL;
			return;
		}
		tmp = tmp->link;
	}
}

/// <summary>
/// 리스트 동적할당 해제
/// </summary>
/// <param name="h">해제할 리스트</param>
void freeList(HeadNode* h) {
	ListNode* tmp;
	while (h->head != NULL) {
		tmp = h->head;
		h->head = tmp->link;
		free(tmp);
		tmp = NULL;
	}
}

void SortProgress(char* ary) {
	
	if (strlen(ary) == 0) {
		printf("빈 리스트입니다.\n");
		return;
	}

	if (strlen(ary) == 1) {
		if (ary[0] == 'q' || ary[0] == 'Q') {
			printf("프로그램 종료\n");
			exit(0);
		}
		printf("단일 노드 리스트입니다.\n");
		return;
	}

	


	HeadNode* list;
	HeadNode* list_upper = createLinkedList(); // 대문자 리스트
	HeadNode* list_lower = createLinkedList(); // 소문자 리스트

	// 문자열 입력
	/*printf("문자열 : ");
	gets_s(input_ary, 10);
	printf("==================\n");*/

	// 비정렬 리스트 생성
	list = aryToList(ary);
	printf("비정렬 ");
	printList(list);

	// 리스트 삽입정렬
	insertionSort(list);
	printList(list);

	// 리스트 -> 대문자, 소문자 리스트로 분해
	makeList(list, list_upper, list_lower);

	// 출력 
	printf("대문자 ");
	printList(list_upper);
	printf("소문자 ");
	printList(list_lower);

	// 메모리 반환 
	freeList(list_upper);
	freeList(list_lower);
	printf("==================\n");
}

int main() {
	char input_ary[10];

	while (1) {
		printf("문자열 입력(q : 프로그램 종료) : ");
		gets_s(input_ary, 10);
		printf("==================\n");
		SortProgress(input_ary);
	}

	return 0;
}