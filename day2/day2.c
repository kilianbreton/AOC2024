#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <windows.h>

#define BUF_LEN 64
#define ARRAY_LEN 16

BOOL isValid(char* line)
{
	BYTE lineIndex = 0;
	BYTE arrayIndex = 0;
	short iArray[ARRAY_LEN];
	short tmp;
	BOOL isAsc;
	char buf[BUF_LEN];
	BYTE bufIndex = 0;
	BOOL errorSkiped = FALSE;
	BOOL skip = FALSE;
	
	while (lineIndex < BUF_LEN)
	{
		if (line[lineIndex] != ' ' && line[lineIndex] != '\n' && line[lineIndex] != '\0')
		{
			buf[bufIndex] = line[lineIndex];
			++bufIndex;
		}
		else
		{
			buf[bufIndex] = '\0';
			bufIndex = 0;
			iArray[arrayIndex] = atoi(buf);
			if (arrayIndex > 0)
			{
				tmp = abs(iArray[arrayIndex] - iArray[arrayIndex - 1]);
				if (tmp == 0 || tmp > 3)
				{
					if (errorSkiped == FALSE)
					{
						errorSkiped = TRUE;
						skip = TRUE;
					}
					else
					{
						return FALSE;
					}
				}
				
				if (arrayIndex == 1)
				{
					if (iArray[arrayIndex] - iArray[arrayIndex - 1] > 0)
						isAsc = TRUE;
					else
						isAsc = FALSE;
				}
				else
				{
					if (iArray[arrayIndex] - iArray[arrayIndex - 1] > 0 && isAsc == FALSE && !skip)
					{
						if (errorSkiped == FALSE)
						{
							errorSkiped = TRUE;
							skip = TRUE;
						}
						else
						{
							return FALSE;
						}
					}
					
					if (iArray[arrayIndex] - iArray[arrayIndex - 1] < 0 && isAsc == TRUE && !skip)
					{
						if (errorSkiped == FALSE)
						{
							errorSkiped = TRUE;
							skip = TRUE;
						}
						else
						{
							return FALSE;
						}
					}
				}

				
			}
			if(!skip)
				++arrayIndex;

			skip = FALSE;
			
		}
		if (line[lineIndex] == '\n' || line[lineIndex] == '\0')
		{
			break;
		}
		++lineIndex;
	}
	return TRUE;
}



int main()
{
	FILE* hFile = fopen("C:\\test\\AOC2024\\AOC2.txt", "r");
	if (hFile == NULL)
		return 1;

	char line[BUF_LEN];
	int nb = 0;

	while (fgets(line, BUF_LEN, hFile))
	{
		if (isValid(line))
		{
			nb += 1;
			printf("%s    VALIDE\n", line);
		}
		else
		{
			printf("%s    INVALIDE\n", line);
		}
			
	}

	printf("Result 1 : %d\n", nb);


	return 0;
}