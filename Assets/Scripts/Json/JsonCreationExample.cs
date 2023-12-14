using UnityEngine;

using System.Collections.Generic;
using System;
using System.IO;

//���̶���Ʈ ��� �߰� �ؾ���

[System.Serializable]

public class InstructionHighlight

{

    public string text;

    public ModalContent modalContent;

}



[System.Serializable]

public class Instruction

{

    public string id;

    public string text;

    public float startTime;

    public List<InstructionHighlight> highlights;

}



[System.Serializable]

public class ModalContent

{

    public string title;

    public string image;

}



[System.Serializable]

public class FetchedSlides

{

    public string problemTitle;

    public string problemImage;

    public string problemAnswer;

    public string videoUrl;

    public int videoLength;

    public List<Instruction> instructions;

}

public class JsonCreationExample : MonoBehaviour
{
    public WorkbookSetting workbookSetting;
    public List<Question> questions;
    void Start()
    {
        //makeJson(0); //0������ 3������ 4����
    }

    public void makeJson()
    {
        int number = workbookSetting.quest_num;

        questions = workbookSetting.questions;
        int n = questions.Count;

        // ���� ������ ����

        FetchedSlides fetchedSlides = new FetchedSlides
        {
            problemTitle = "[�⺻] 6-2. �ﰢ���� ���༱",

            problemImage = "https://capston-moving.s3.ap-northeast-2.amazonaws.com/6-3-" + number + ".png",

            problemAnswer = "���� : 2��",

            videoUrl = "https://capston-moving.s3.ap-northeast-2.amazonaws.com/6-3-" + number + ".mp4",

            videoLength = 18,

            instructions = new List<Instruction>
            {
                new Instruction
                {
                    id = "1",
                    text = questions[number].slides[0].linesets[0].sentence,
                    startTime = 0,
                    highlights = questions[number].slides[0].linesets[0].hyperText_name != "" ? new List<InstructionHighlight>
                    {
                        new InstructionHighlight
                        {
                            text = questions[number].slides[0].linesets[0].hyperText_name,
                            modalContent = new ModalContent
                            {
                                title = questions[number].slides[0].linesets[0].hyperText_name,
                                image = questions[number].slides[0].linesets[0].hyperText_link
                            }
                        }
                    } : new List<InstructionHighlight>()
                },

                new Instruction
                {
                    id = "2",
                    text = questions[number].slides[0].linesets[1].sentence,
                    startTime = 2,
                    highlights = questions[number].slides[0].linesets[1].hyperText_name != "" ? new List<InstructionHighlight>
                    {
                        new InstructionHighlight
                        {
                            text = questions[number].slides[0].linesets[1].hyperText_name,
                            modalContent = new ModalContent
                            {
                                title = questions[number].slides[0].linesets[1].hyperText_name,
                                image = questions[number].slides[0].linesets[1].hyperText_link
                            }
                        }
                    } : new List<InstructionHighlight>()
                },

                new Instruction
                {
                    id = "3",
                    text = questions[number].slides[0].linesets[2].sentence,
                    startTime = 4,
                    highlights = questions[number].slides[0].linesets[2].hyperText_name != "" ? new List<InstructionHighlight>
                    {
                        new InstructionHighlight
                        {
                            text = questions[number].slides[0].linesets[2].hyperText_name,
                            modalContent = new ModalContent
                            {
                                title = questions[number].slides[0].linesets[2].hyperText_name,
                                image = questions[number].slides[0].linesets[2].hyperText_link
                            }
                        }
                    } : new List<InstructionHighlight>()
                },

                new Instruction
                {
                    id = "4",
                    text = questions[number].slides[1].linesets[0].sentence,
                    startTime = 6,
                    highlights = questions[number].slides[1].linesets[0].hyperText_name != "" ? new List<InstructionHighlight>
                    {
                        new InstructionHighlight
                        {
                            text = questions[number].slides[1].linesets[0].hyperText_name,
                            modalContent = new ModalContent
                            {
                                title = questions[number].slides[1].linesets[0].hyperText_name,
                                image = questions[number].slides[1].linesets[0].hyperText_link
                            }
                        }
                    } : new List<InstructionHighlight>()
                },

                new Instruction
                {
                    id = "5",
                    text = questions[number].slides[1].linesets[1].sentence,
                    startTime = 8,
                    highlights = questions[number].slides[1].linesets[1].hyperText_name != "" ? new List<InstructionHighlight>
                    {
                        new InstructionHighlight
                        {
                            text = questions[number].slides[1].linesets[1].hyperText_name,
                            modalContent = new ModalContent
                            {
                                title = questions[number].slides[1].linesets[1].hyperText_name,
                                image = questions[number].slides[1].linesets[1].hyperText_link
                            }
                        }
                    } : new List<InstructionHighlight>()
                },

                new Instruction
                {
                    id = "6",
                    text = questions[number].slides[1].linesets[2].sentence,
                    startTime = 10,
                    highlights = questions[number].slides[1].linesets[2].hyperText_name != "" ? new List<InstructionHighlight>
                    {
                        new InstructionHighlight
                        {
                            text = questions[number].slides[1].linesets[2].hyperText_name,
                            modalContent = new ModalContent
                            {
                                title = questions[number].slides[1].linesets[2].hyperText_name,
                                image = questions[number].slides[1].linesets[2].hyperText_link
                            }
                        }
                    } : new List<InstructionHighlight>()
                },

                new Instruction
                {
                    id = "7",
                    text = questions[number].slides[2].linesets[0].sentence,
                    startTime = 12,
                    highlights = questions[number].slides[2].linesets[0].hyperText_name != "" ? new List<InstructionHighlight>
                    {
                        new InstructionHighlight
                        {
                            text = questions[number].slides[2].linesets[0].hyperText_name,
                            modalContent = new ModalContent
                            {
                                title = questions[number].slides[2].linesets[0].hyperText_name,
                                image = questions[number].slides[2].linesets[0].hyperText_link
                            }
                        }
                    } : new List<InstructionHighlight>()
                },

                new Instruction
                {
                    id = "8",
                    text = questions[number].slides[2].linesets[1].sentence,
                    startTime = 14,
                    highlights = questions[number].slides[2].linesets[1].hyperText_name != "" ? new List<InstructionHighlight>
                    {
                        new InstructionHighlight
                        {
                            text = questions[number].slides[2].linesets[1].hyperText_name,
                            modalContent = new ModalContent
                            {
                                title = questions[number].slides[2].linesets[1].hyperText_name,
                                image = questions[number].slides[2].linesets[1].hyperText_link
                            }
                        }
                    } : new List<InstructionHighlight>()

                },

                new Instruction
                {
                    id = "9",
                    text = questions[number].slides[2].linesets[2].sentence,
                    startTime = 16,
                    highlights = questions[number].slides[2].linesets[2].hyperText_name != "" ? new List<InstructionHighlight>
                    {
                        new InstructionHighlight
                        {
                            text = questions[number].slides[2].linesets[2].hyperText_name,
                            modalContent = new ModalContent
                            {
                                title = questions[number].slides[2].linesets[2].hyperText_name,
                                image = questions[number].slides[2].linesets[2].hyperText_link
                            }
                        }
                    } : new List<InstructionHighlight>()
                }
            }

        };



        // JSON ������ ���ڿ��� ��ȯ

        string json = JsonUtility.ToJson(fetchedSlides, true);

        // �����͸� ������ ��� ����
        //string path = Path.Combine(Application.dataPath, "Upload/movingData.json");
        // ���� ���� �� ����
        string path = "E:/UnityProject/MovingCapstone/Video/6-3-" + number + ".json";
        File.WriteAllText(path, json);


        // JSON ���

        Debug.Log(json);
    }


}