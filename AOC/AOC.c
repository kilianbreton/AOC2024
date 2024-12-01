#pragma warning(disable : 4996)

#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int leftArray[1024];
int rightArray[1024];


int intComparator(const void* first, const void* second) 
{
	int firstInt = *(const int*)first;
	int secondInt = *(const int*)second;
	return firstInt - secondInt;
}


int countInRightArray(int num, int lim)
{
	int i;
	int r = 0;;
	for (i = 0; i <= lim; ++i)
	{
		if (rightArray[i] == num)
			r += 1;

	}
	return r;
}


int main()
{
	FILE* hFile = fopen("D:\\AOC\\AOC1.txt", "r");
	char line[64];
	int index = 0;
	int lim = 0;
	int i;
	long tmp = 0;
	long res = 0;

	char* buf = malloc(6);
	if (buf == NULL)
		return 1;


	while (fgets(line, sizeof(line), hFile))
	{
		memcpy(buf, line, 5);
		buf[5] = '\0';
		leftArray[index] = atoi(buf);
		
		memcpy(buf, line + 8, 5);
		buf[5] = '\0';
		rightArray[index] = atoi(buf);

		++index;
	}
	lim = index - 1;

	qsort(leftArray, lim, sizeof(int), intComparator);
	qsort(rightArray, lim, sizeof(int), intComparator);

	
	//resolve 1
	for (i = 0; i <= lim; ++i)
	{
		tmp = abs(leftArray[i] - rightArray[i]);
		if(tmp >0)
			res += tmp;
	}
	printf("Result 1  : %d\n", res);


	//resolve 2
	res = 0;
	for (i = 0; i <= lim; ++i)
	{
		res += countInRightArray(leftArray[i], lim) * leftArray[i];
	}
	printf("Result 2  : %d\n", res);









	return 0;
}