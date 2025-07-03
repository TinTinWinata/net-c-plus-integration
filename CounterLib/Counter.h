#pragma once

class Counter {
	private:
		int value;
	public:
		Counter(int value);
		void Increment();
		int GetValue();
};