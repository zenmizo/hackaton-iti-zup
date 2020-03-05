//
//  ResultOperationScreen.swift
//  hackaton-iOS
//
//  Created by Zendji Mizoguchi on 05/03/20.
//  Copyright © 2020 Zendji Mizoguchi. All rights reserved.
//

import Foundation
import BeagleUI

struct ResultOperationScreen {
    
    func createScreen() -> Screen {
       let screen = Screen(
              content: getBody()
        )
        return screen
    }
    
    func getBody() -> Container {
        var containerChilder: [ServerDrivenComponent] = []
        
        let containerSize = Flex.Size(width: UnitValue(value: 100.0, type: UnitType.percent), height: UnitValue(value: 33.0, type: UnitType.real))
        
        let containerFlex = Flex(justifyContent: Flex.JustifyContent.spaceAround,
                                 alignItems: Flex.Alignment.center,
                                 size: containerSize)
        
        containerChilder.append(Container(children: [Image(name: "success")], flex: containerFlex))
        
        
        containerChilder.append(Container(children:
            [
         Text("Oopes", alignment: Text.Alignment.center, textColor: "FE5886"),
         Text("Something wrong happened.", alignment: Text.Alignment.center, textColor: "000000")],
                                          flex: containerFlex))
        
        
        let sizeButton = Flex.Size(width: UnitValue(value: 80.0, type: UnitType.percent), height: UnitValue(value: 24.0, type: UnitType.real))
        
        let flexButton = Flex(size: sizeButton)
        
        let buttonApperance = Appearance(backgroundColor: "FE5789")

        
        containerChilder.append(Container(children:
           [
         Button(text: "go to home", appearance: buttonApperance, flex: flexButton)
            ],
                                         flex: containerFlex))
        
        
        let sizeContainers = Flex.Size(width: UnitValue(value: 100.0, type: UnitType.percent), height: UnitValue(value: 100.0, type: UnitType.percent))
        
        let flexContainer = Flex(justifyContent: Flex.JustifyContent.spaceBetween, alignItems: Flex.Alignment.auto, size: sizeContainers)
        
        let buttonAppderance = Appearance(backgroundColor: "F6CA2C")
        
        return  Container(children: containerChilder, flex: flexContainer, appearance: buttonAppderance)
    }
    
}
