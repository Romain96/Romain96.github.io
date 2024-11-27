---
title: "Talk at Journée cancer du pancréas"
collection: talks
type: "Conference talk"
permalink: /talks/2023-12-JourneePancreas-talk
venue: "Centre hospitalo-universitaire de Besançon"
date: 2023-12-01
location: "Besançon, France"
---

Context
======

I have been invited to give a short talk during the [*Journée cancer du pancréas*](https://www.canceropole-est.org/journee-cancer-du-pancreas) organized by the [Cancéropôle Est](https://www.canceropole-est.org/) on the 1st of december 2023.
The joint talk was given alongside my colleague Arthur Bénédic from the [CHU de Strasbourg](https://www.chru-strasbourg.fr/).
The slides for this presentation are available [here](/files/2023-JourneePancreas-slides.pdf).

Special thanks to Dr. [Florence Schaffner](https://www.canceropole-est.org/la-recherche/annuaire-du-canceropole-est/personnes/detail?id=2593) ([Cancéropôle Est](https://www.canceropole-est.org/)) for the invitation.

Thanks to Dr. Gerlinde Lang-Avérous ([CHU de Strasbourg](https://www.chru-strasbourg.fr/)) and Dr. Arthur Bénédic ([CHU de Strasbourg](https://www.chru-strasbourg.fr/)).


The proposed method
======

We have presented a new experimental and automatic method designed to produce an *immune score* given a pancreatic H&E slide.
The objective is to reproduce the human methodology and to automate it.

Step 1
-----

Firstly, the *color deconvolution*[^1] method is applied to the input image in order to extract the *positive* signal in the *DAB* channel.

| RGB image | Hematoxylin channel | DAB channel |
|:---------:|:-------------------:|:-----------:|
| ![](/files/2023-JourneePancreas/deconvolution_rgb.png){width="250"} | ![](/files/2023-JourneePancreas/deconvolution_hematoxylin.png){width="250"} | ![](/files/2023-JourneePancreas/deconvolution_dab.png){width="250"} |

Secondly, a filtering step is applied to the entire image.
It consists of a morphological filter based on *opening* and *closing* operations.
In *gray mathematical morphology*, the core operations are the *morphological erosion* and the *morphological dilation* which emulate their real life counterpart given a shape called the *structuring element*.
These core operations can be combined to form the *morphological opening* (a dilation followed by an erosion) and *morphological closing* (an erosion followed by a dilation).
These operations are able to filter the signal by removing small islets (artifacts), filling shapes exhibiting cavities (if smaller than the structuring element), and merging/separating objects depending on the size and shape of the structuring element.
In our work, the structuring element is chosen to represent the *smallest average cell*.
It is then defined as a disk whose radius is small enough for every detectable cell to be larger.

| Input RGB | DAB channel | Thresholding | Filtering | Cell counting |
|:---------:|:-----------:|:------------:|:---------:|:-------------:|
| ![](/files/2023-JourneePancreas/input.png){width="250"} | ![](/files/2023-JourneePancreas/dab.png){width="250"} | ![](/files/2023-JourneePancreas/dab_thresholding.png){width="250"} | ![](/files/2023-JourneePancreas/dab_filtering.png){width="250} | ![](/files/2023-JourneePancreas/output.png){width="250"} |

Step 2
-----

Each connected component is extracted from the filtered image.
For each of these clusters, the surface area is simply divided by the area of a reference cell, chosen to be the average cell of the studied cell type.
The sum of all estimated cells for every cluster forms the *cell quantification estimate*.

Step 3
-----

In order to account for variable tissue size and deformation, the surface area of said tissue is also estimated using the [QuPath](https://qupath.github.io/) software.
The resulting area forms the *tissue surface area estimate*.
The final metric is obtained by joining the two estimates together in order to form a *cell quantification estimate by surface area unit* which is has been set to be expressed as a number of estimated cells per unit of 1mm².

[^1]: Ruifrok A.C. and Johnston D.A. Quantification of histochemical staining by color deconvolution. Anal Quant Cytol Histol. 2001 Aug;23(4):291-9