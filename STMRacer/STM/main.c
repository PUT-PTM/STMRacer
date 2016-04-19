#include "stm32f4xx.h"
#include "stm32f4xx_gpio.h"
#include "stm32f4xx_spi.h"
#include "stm32f4_discovery_lis302dl.h"

int8_t przys_x;
int8_t przys_y;
int8_t przys_z;

void Init(){

LIS302DL_InitTypeDef LIS302DL_InitStruct;

// Konfiguracja LIS302DL
//LIS302DL_InitStruct.Power_Mode=LIS302DL_LOWPOWERMODE_ACTIVE;
LIS302DL_InitStruct.Output_DataRate=LIS302DL_DATARATE_100;
LIS302DL_InitStruct.Axes_Enable=LIS302DL_X_ENABLE | LIS302DL_Y_ENABLE | LIS302DL_Z_ENABLE;
LIS302DL_InitStruct.Full_Scale=LIS302DL_FULLSCALE_2_3;
LIS302DL_InitStruct.Self_Test=LIS302DL_SELFTEST_NORMAL;
LIS302DL_Init(&LIS302DL_InitStruct);

SystemInit();
GPIO_InitTypeDef  GPIO_InitStructure;
RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);

GPIO_InitStructure.GPIO_Pin = GPIO_Pin_12 | GPIO_Pin_13| GPIO_Pin_14| GPIO_Pin_15;
GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
GPIO_Init(GPIOD, &GPIO_InitStructure);

// OpóŸnienie
for (int i=0;i<100000;i++);

}

int main(void)
{

	Init();

    while(1)
    {

    	LIS302DL_Read(&przys_x, LIS302DL_OUT_X_ADDR, 1);
    	LIS302DL_Read(&przys_y, LIS302DL_OUT_Y_ADDR, 1);

    	//LIS302DL_Read(&przys_z, LIS302DL_OUT_Z_ADDR, 1);

    	for(int i=0; i<100000; i++){};



    	if(przys_x>0)
    			{
    				GPIO_SetBits(GPIOD,GPIO_Pin_14);
    				GPIO_ResetBits(GPIOD, GPIO_Pin_12);
    			}

    	if(przys_y>0)
    	    			{
    	    				GPIO_SetBits(GPIOD,GPIO_Pin_13);
    	    				GPIO_ResetBits(GPIOD, GPIO_Pin_15);
    	    			}

    	if(przys_x<0)
    			{
    				GPIO_SetBits(GPIOD,GPIO_Pin_12);
    				GPIO_ResetBits(GPIOD, GPIO_Pin_14);
    			}

    	if(przys_y<0)
    	    			{
    	    				GPIO_SetBits(GPIOD,GPIO_Pin_15);
    	    				GPIO_ResetBits(GPIOD, GPIO_Pin_13);
    	    			}

    }
}
