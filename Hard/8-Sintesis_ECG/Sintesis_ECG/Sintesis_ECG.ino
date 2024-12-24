#include <LiquidCrystal.h>

// Configuración de pines para el LCD
const int rs = 13;  // Pin RS del LCD conectado a D13
const int en = 12;  // Pin E del LCD conectado a D12
const int d4 = A3;  // Pin D4 del LCD conectado a A3
const int d5 = A2;  // Pin D5 del LCD conectado a A2
const int d6 = A1;  // Pin D6 del LCD conectado a A1
const int d7 = A0;  // Pin D7 del LCD conectado a A0

// Pin PWM
const int pwmPin = 9;  // Pin PWM para salida (LED o carga)

// Inicializar el objeto LiquidCrystal con los pines definidos
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);

void setup() {
  // Configuración del LCD: 16 columnas y 2 filas
  lcd.begin(16, 2);

  // Mensajes iniciales
  lcd.print("Hola, Mundo!");  // Mostrar mensaje en la primera línea
  //lcd.setCursor(0, 1);       // Mover el cursor a la segunda línea

  pinMode(pwmPin, OUTPUT);
  pinMode(8, OUTPUT);
  digitalWrite(8, HIGH);
}

void loop() {
  // Aumentar brillo del LED
  for (int i = 0; i <= 255; i++) {
    analogWrite(pwmPin, i);      // Cambiar el ciclo útil de 0 a 100%
    delay(1);                   // Pausa para suavizar el cambio
  }
/*
  // Disminuir brillo del LED
  for (int i = 255; i >= 0; i--) {
    analogWrite(pwmPin, i);      // Cambiar el ciclo útil de 100% a 0
    delay(10);                   // Pausa para suavizar el cambio
  }
  */
}
