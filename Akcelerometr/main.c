#include "stm32f4xx_conf.h"
#include "stm32f4xx.h"
#include "stm32f4xx_gpio.h"
#include "usbd_cdc_core.h"
#include "usbd_usr.h"
#include "usbd_desc.h"
#include "usbd_cdc_vcp.h"
#include "usb_dcd_int.h"
#include "stm32f4xx_tim.h"
#include "stm32f4_discovery_lis302dl.h"
#include <main.h>
#include <codec.h>
#include <codec.c>

int8_t przys_x;
int8_t przys_y;
int8_t przys_z;

char znaki[1]={'X'};

__ALIGN_BEGIN USB_OTG_CORE_HANDLE  USB_OTG_dev __ALIGN_END;

#define HSE_VALUE    ((uint32_t)8000000)

 void init()
 {
	 LIS302DL_InitTypeDef AccInitStr;
	 	AccInitStr.Axes_Enable = LIS302DL_XYZ_ENABLE;
	 	AccInitStr.Full_Scale = LIS302DL_FULLSCALE_2_3;
	 	AccInitStr.Power_Mode = LIS302DL_LOWPOWERMODE_ACTIVE;
	 	AccInitStr.Output_DataRate = LIS302DL_DATARATE_100;
	 	AccInitStr.Self_Test = LIS302DL_SELFTEST_NORMAL;
	 	LIS302DL_Init(&AccInitStr);

 	GPIO_InitTypeDef  GPIO_InitStructure;
 	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);

 	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_12 | GPIO_Pin_13| GPIO_Pin_14| GPIO_Pin_15;
 	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
 	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
 	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
 	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
 	GPIO_Init(GPIOD, &GPIO_InitStructure);

	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_100MHz;
	GPIO_InitStructure.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_Init(GPIOA, &GPIO_InitStructure);

 	USBD_Init(&USB_OTG_dev,USB_OTG_FS_CORE_ID,&USR_desc,&USBD_CDC_cb,&USR_cb);
    }


 void OTG_FS_IRQHandler(void)
 {
   USBD_OTG_ISR_Handler (&USB_OTG_dev);
 }

 void OTG_FS_WKUP_IRQHandler(void)
 {
   if(USB_OTG_dev.cfg.low_power)
   {
     *(uint32_t *)(0xE000ED10) &= 0xFFFFFFF9 ;
     SystemInit();
     USB_OTG_UngateClock(&USB_OTG_dev);
   }
 }


int main(void)
{
	SystemInit();

	for(int i =0; i<1000;i++);

	init();

	// Sound
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);

	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_15;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;

	GPIO_Init(GPIOD, &GPIO_InitStructure);

	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOC, ENABLE);

	codec_init();
	codec_ctrl_init();

	I2S_Cmd(CODEC_I2S, ENABLE);

	int timer;
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM2,ENABLE);
	TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;
	TIM_TimeBaseStructure.TIM_Period = 20000;
	TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;
	TIM_TimeBaseStructure.TIM_Prescaler = 100;
	TIM_TimeBaseStructure.TIM_ClockDivision = TIM_CKD_DIV1;
	TIM_TimeBaseStructure.TIM_RepetitionCounter = 0;
	TIM_TimeBaseInit(TIM2, &TIM_TimeBaseStructure);
	TIM_Cmd(TIM2, ENABLE);

	const uint8_t function[10] = { 0x10,0x20,0x30,0x40,0x40,0x30,0x20,0x10,0x80, 0x90 };

	while (1){



		LIS302DL_Read(&przys_x, LIS302DL_OUT_X_ADDR, 1);
		LIS302DL_Read(&przys_y, LIS302DL_OUT_Y_ADDR, 1);
		timer = TIM_GetCounter(TIM2);



		if(przys_x>30)
		{
			znaki[0]='A';
			GPIO_SetBits(GPIOD,GPIO_Pin_14);
			GPIO_ResetBits(GPIOD, GPIO_Pin_12|GPIO_Pin_15|GPIO_Pin_13);

			if (SPI_I2S_GetFlagStatus(CODEC_I2S, SPI_I2S_FLAG_TXE))
			{
				SPI_I2S_SendData(CODEC_I2S, function);

			}

		}

		if(przys_y<-30)
		{
			znaki[0]='W';
			GPIO_SetBits(GPIOD,GPIO_Pin_15);
			GPIO_ResetBits(GPIOD, GPIO_Pin_13|GPIO_Pin_12|GPIO_Pin_14);

			if (SPI_I2S_GetFlagStatus(CODEC_I2S, SPI_I2S_FLAG_TXE))
			{
				SPI_I2S_SendData(CODEC_I2S, function);

			}
		}

		if(przys_x<-30)
		{
			znaki[0]='D';
			GPIO_SetBits(GPIOD,GPIO_Pin_12);
			GPIO_ResetBits(GPIOD, GPIO_Pin_13|GPIO_Pin_14|GPIO_Pin_15);

			if (SPI_I2S_GetFlagStatus(CODEC_I2S, SPI_I2S_FLAG_TXE))
			{
				SPI_I2S_SendData(CODEC_I2S, function);

			}

		}

		if((przys_x>-30) &&  (przys_x<30) && (przys_y>-30) &&  (przys_y<30))
				{
			znaki[0]='X';
				}

		if(przys_y>30)
		{
				znaki[0]='S';
				GPIO_SetBits(GPIOD,GPIO_Pin_13);
				GPIO_ResetBits(GPIOD, GPIO_Pin_14|GPIO_Pin_15|GPIO_Pin_12);

				if (SPI_I2S_GetFlagStatus(CODEC_I2S, SPI_I2S_FLAG_TXE))
				{
					SPI_I2S_SendData(CODEC_I2S, function);

				}
		}

		if(GPIO_ReadInputDataBit(GPIOA,GPIO_Pin_0))
		{
			znaki[0]='B';
			GPIO_SetBits(GPIOD, GPIO_Pin_14|GPIO_Pin_15|GPIO_Pin_12|GPIO_Pin_13);
		}

		if(timer==250){
			VCP_send_buffer(&znaki,1);
		}
		GPIO_ResetBits(GPIOD, GPIO_Pin_14|GPIO_Pin_15|GPIO_Pin_12|GPIO_Pin_13);
	}

	return 0;

}


