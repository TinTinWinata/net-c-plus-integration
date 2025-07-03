#include "pch.h"
#include "Counter.h"

#define API __declspec(dllexport)

extern "C" {
	API Counter* CreateCounter(int value) {
		return new Counter(value);
	}
	API void DisposeCounter(Counter* counter) {
		delete counter;
	}
	API void IncrementCounter(Counter* counter) {
		counter->Increment();
	}
	API int GetCounterValue(Counter* counter) {
		return counter->GetValue();
	}
}