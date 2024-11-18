long valor=0;

void setup() {
  // put your setup code here, to run once:
    Serial.begin(115200);
    analogReference(INTERNAL);
}

void loop() {
  // put your main code here, to run repeatedly:
 valor = analogRead(A0);
 
  //Imprimimos por el monitor serie
  Serial.println(valor);
  delay(1);
}
