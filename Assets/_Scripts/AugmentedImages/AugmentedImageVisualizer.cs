//-----------------------------------------------------------------------
// <copyright file="AugmentedImageVisualizer.cs" company="Google">
//
// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;

    /// <summary>
    /// Uses 4 frame corner objects to visualize an AugmentedImage.
    /// </summary>
    public class AugmentedImageVisualizer : MonoBehaviour
    {
        /// <summary>
        /// The AugmentedImage to visualize.
        /// </summary>
        public AugmentedImage Image;

        public Camera Camera;

        public GameObject CurrentGameObject;

        private void Start()
        {
            
        }

        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public void Update()
        {
            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {
                CurrentGameObject.SetActive(false);
                return;
            }

            ////If the object changed
            //if(CurrentGameObject != CatalogManager.Instance.CurrentObject.Prefab)
            //{
            //    Destroy(CurrentGameObject.gameObject);
            //    CurrentGameObject = Instantiate(CatalogManager.Instance.CurrentObject.Prefab);
            //}

            float halfWidth = Image.ExtentX / 2;
            float halfHeight = Image.ExtentZ / 2;

            CurrentGameObject.transform.localPosition = Image.CenterPose.position;
            CurrentGameObject.transform.rotation = Quaternion.Euler(0, 180, 0);

            CurrentGameObject.SetActive(true);

            //FrameLowerLeft.transform.localPosition =
            //    (halfWidth * Vector3.left) + (halfHeight * Vector3.back);
            //FrameLowerRight.transform.localPosition =
            //    (halfWidth * Vector3.right) + (halfHeight * Vector3.back);
            //FrameUpperLeft.transform.localPosition =
            //    (halfWidth * Vector3.left) + (halfHeight * Vector3.forward);
            //FrameUpperRight.transform.localPosition =
            //    (halfWidth * Vector3.right) + (halfHeight * Vector3.forward);

            //FrameLowerLeft.SetActive(true);
            //FrameLowerRight.SetActive(true);
            //FrameUpperLeft.SetActive(true);
            //FrameUpperRight.SetActive(true);
        }
    }
}
