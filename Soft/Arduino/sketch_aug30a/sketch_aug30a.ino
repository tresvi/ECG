long valor=0;
void setup() {
  // put your setup code here, to run once:
    Serial.begin(115200);
    
    pinMode(A1, OUTPUT);

    
}

void loop() {
  // put your main code here, to run repeatedly:
 valor = analogRead(A0);

 digitalWrite(A1, HIGH);
  //Imprimimos por el monitor serie
  Serial.println(valor);
  digitalWrite(A1, LOW);
  //delay(1);
  delayMicroseconds(1000 - 135); //Calculado 173, medido: 158
}
