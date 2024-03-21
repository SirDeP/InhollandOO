#ifndef OOSTACK_H
#define OOSTACK_H

class OOStack {

private:
	int aantal;
	const int maxAantalElementen;

public:
	int Aantal();

	int Pop();

	void Push(int getal);

	void Print();
};

#endif
