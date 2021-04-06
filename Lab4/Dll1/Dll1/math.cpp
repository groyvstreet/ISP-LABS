#include "pch.h"

int __stdcall Module(int num)
{
	if (num >= 0)
	{
		return num;
	}
	else
	{
		return 0 - num;
	}
}

double __stdcall ModuleD(double num)
{
	if (num >= 0)
	{
		return num;
	}
	else
	{
		return (0 - num);
	}
}

int __stdcall Max(int num1, int num2)
{
	if (num1 >= num2)
	{
		return num1;
	}
	else
	{
		return num2;
	}
}

int __stdcall Min(int num1, int num2)
{
	if (num1 <= num2)
	{
		return num1;
	}
	else
	{
		return num2;
	}
}

int __stdcall Pow(int num, int level)
{
	if (level == 1)
	{
		return num;
	}
	else
	{
		return num * Pow(num, --level);
	}
}

double __cdecl Sin(double x)
{
	double num1 = x, num2 = 1, sin = x;

	for (int i = 0; i < 10; i++)
	{
		num1 *= -1;
		num1 *= x;
		num1 *= x;
		num1 /= ++num2;
		num1 /= ++num2;
		sin += num1;
	}

	return sin;
}

double __cdecl Cos(double x)
{
	double num1 = 1, num2 = 0, cos = 1;

	for (int i = 0; i < 10; i++)
	{
		num1 *= -1;
		num1 *= x;
		num1 *= x;
		num1 /= ++num2;
		num1 /= ++num2;
		cos += num1;
	}

	return cos;
}

double __cdecl Tg(double x)
{
	if (Cos(x) != 0)
	{
		return Sin(x) / Cos(x);
	}
	else
	{
		return NULL;
	}
}

double __cdecl Ctg(double x)
{
	if (Sin(x) != 0)
	{
		return Cos(x) / Sin(x);
	}
	else
	{
		return NULL;
	}
}
