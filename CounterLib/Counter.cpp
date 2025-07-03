#include "pch.h"
#include "Counter.h"

Counter::Counter(int value) {
	this->value = value;
}

void Counter::Increment() {
	this->value += 1;
}

int Counter::GetValue() {
	return this->value;
}