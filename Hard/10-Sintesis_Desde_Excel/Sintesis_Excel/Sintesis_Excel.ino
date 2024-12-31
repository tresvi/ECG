
// Tabla de valores exportada desde Excel
const unsigned char tabla[32] = {0 ,85 ,170 ,255 ,0 ,85 ,170 ,255 ,0 ,8
   ,17 ,20 ,21 ,21 ,21 ,20 ,17 ,8 ,255 ,255
   ,255 ,255 ,255 ,255 ,255 ,255 ,255 ,255 ,0 ,0
   ,0 ,0
};

const int pwmPin = 9;

void setup() {
  // Configurar el pin 9 como salida
  pinMode(9, OUTPUT);

TCCR1A = 0b00000001 ; // 8 bits
TCCR1B = 0b00001001 ; // x1 pwm rápido
  // Habilitar salida PWM en el pin 9 (OC1A)
  TCCR1A |= (1 << COM1A1);
  analogWrite(9, 127);  // 50% de ciclo de trabajo
}

void loop() {
  // El pin 9 ya está emitiendo la señal PWM de 62.5 kHz
  // No es necesario hacer nada en el loop
}

/*
void setup() {
  pinMode(pwmPin, OUTPUT);

  // Seteo Timer1 para tener la
  // frec. maxima de PWM (62.5 kHz)
  TCCR1A = _BV(COM1A1) | _BV(WGM11); 
  TCCR1B = _BV(WGM13) | _BV(CS10);  
}

void loop() {
  analogWrite(pwmPin, tabla[i]);

  for (int i = 0; i < 10; i++) {
    analogWrite(pwmPin, tabla[i]);
    //Delay para tiempo de muestreo
    delayMicroseconds(10000);
  }  
}*/
