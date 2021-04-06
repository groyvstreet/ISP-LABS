#pragma once

#ifdef MATH_EXPORTS
#define MATH_API __declspec(dllexport)
#else
#define MATH_API __declspec(dllimport)
#endif

extern "C" MATH_API int __stdcall Module(int num);
extern "C" MATH_API double __stdcall ModuleD(double num);
extern "C" MATH_API int __stdcall Max(int num1, int num2);
extern "C" MATH_API int __stdcall Min(int num1, int num2);
extern "C" MATH_API int __stdcall Pow(int num, int level);
extern "C" MATH_API double __cdecl Sin(double x);
extern "C" MATH_API double __cdecl Cos(double x);
extern "C" MATH_API double __cdecl Tg(double x);
extern "C" MATH_API double __cdecl Ctg(double x);
