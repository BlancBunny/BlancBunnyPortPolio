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
/// ���ο� ����Ʈ ���� 
/// </summary>
/// <returns>�� ����Ʈ ��ȯ</returns>
HeadNode* createLinkedList() {
	HeadNode* h;
	h = (HeadNode*)malloc(sizeof(HeadNode));
	if (h != NULL) h->head = NULL;
	return h;
}

/// <summary>
/// ���ο� ��� ����
/// </summary>
/// <param name="ch">��忡 ���Ե� ������ (������)</param>
/// <returns>��� ��ȯ</returns>
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
/// ����Ʈ ���� ���� ��� ����
/// </summary>
/// <param name="h">����Ʈ ���</param>
/// <param name="newNode">������ ���</param>
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
/// ����Ʈ ��� �Լ�
/// </summary>
/// <param name="h">����� ����Ʈ</param>
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
/// �迭 -> ����Ʈ ��ȯ �Լ�
/// </summary>
/// <param name="ary">��ȯ�� �迭</param>
/// <returns>��ȯ�� ����Ʈ</returns>
HeadNode* aryToList(char* ary) {
	HeadNode* h = createLinkedList();
	for (int i = 0; ary[i] != 0; i++) {
		insertLastNode(h, createNode(ary[i]));
	}
	return h;
}


/// <summary>
/// �������� �Լ� : ����Ʈ�� ���ο� ��带 �����ϸ鼭 ����
/// </summary>
/// <param name="h">���� ����Ʈ</param>
/// <param name="newNode">������ ���</param>
void sortedInsert(HeadNode* h, ListNode* newNode) {
	ListNode* curr; 
	// ��� �����Ϳ� ���Ե� ��
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
/// ����Ʈ ���� ���� :
/// ������ ����Ʈ�� sorted ����Ʈ�� �����ϸ鼭 ����
/// �ϼ��� sorted ����Ʈ�� h�� ����
/// </summary>
/// <param name="h">������ ����Ʈ</param>
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
/// ���ĵ� ����Ʈ�� �빮�ڿ� �ҹ��ڷ� �з��ϴ� �Լ�
/// </summary>
/// <param name="h">���ĵ� ����Ʈ</param>
/// <param name="h_upper">�빮�� ����Ʈ</param>
/// <param name="h_lower">�ҹ��� ����Ʈ</param>
void makeList(HeadNode* h, HeadNode* h_upper, HeadNode* h_lower) {
	ListNode* tmp = h->head;
	ListNode* node;
	h_upper->head = h->head;
	while (tmp->link != NULL) {
		// ��, �ҹ��� ��� ��� Ž��
		if (tmp->data >= 'A' && tmp->data <= 'Z' && tmp->link->data >= 'a' && tmp->link->data <= 'z') { 
			h_lower->head = tmp->link;
			tmp->link = NULL;
			return;
		}
		tmp = tmp->link;
	}
}

/// <summary>
/// ����Ʈ �����Ҵ� ����
/// </summary>
/// <param name="h">������ ����Ʈ</param>
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
		printf("�� ����Ʈ�Դϴ�.\n");
		return;
	}

	if (strlen(ary) == 1) {
		if (ary[0] == 'q' || ary[0] == 'Q') {
			printf("���α׷� ����\n");
			exit(0);
		}
		printf("���� ��� ����Ʈ�Դϴ�.\n");
		return;
	}

	


	HeadNode* list;
	HeadNode* list_upper = createLinkedList(); // �빮�� ����Ʈ
	HeadNode* list_lower = createLinkedList(); // �ҹ��� ����Ʈ

	// ���ڿ� �Է�
	/*printf("���ڿ� : ");
	gets_s(input_ary, 10);
	printf("==================\n");*/

	// ������ ����Ʈ ����
	list = aryToList(ary);
	printf("������ ");
	printList(list);

	// ����Ʈ ��������
	insertionSort(list);
	printList(list);

	// ����Ʈ -> �빮��, �ҹ��� ����Ʈ�� ����
	makeList(list, list_upper, list_lower);

	// ��� 
	printf("�빮�� ");
	printList(list_upper);
	printf("�ҹ��� ");
	printList(list_lower);

	// �޸� ��ȯ 
	freeList(list_upper);
	freeList(list_lower);
	printf("==================\n");
}

int main() {
	char input_ary[10];

	while (1) {
		printf("���ڿ� �Է�(q : ���α׷� ����) : ");
		gets_s(input_ary, 10);
		printf("==================\n");
		SortProgress(input_ary);
	}

	return 0;
}